using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using mksolucion.Models;
using System.Net.Mail;
using mksolucion.Funtion.Mail;



namespace mksolucion.Controllers
{
    public class CuentasController : Controller
    {
        // GET: Cuentas
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public CuentasController()
        {
        }

        public CuentasController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Users/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Users/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // No cuenta los errores de inicio de sesión para el bloqueo de la cuenta
            // Para permitir que los errores de contraseña desencadenen el bloqueo de la cuenta, cambie a shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: true);
            switch (result)
            {
                case SignInStatus.Success:
                    if (string.IsNullOrEmpty(returnUrl))
                    {

                        ModelMK db = new ModelMK();
                        var query = from usr in db.AspNetUsers
                             join usrrl in db.AspNetUserRoles on usr.Id equals usrrl.UserId
                             join rol in db.AspNetRoles on usrrl.RoleId equals rol.Id
                             where usr.UserName == model.Email

                             select new
                             {
                                 UserId = usr.Id,
                                 Rolname = rol.Name,
                                 usr.UserName
                             };

                        string urlretorno = string.Empty;

                         if (query.Count() > 0)
                         {
                             var datos = query.ToList();
                             foreach (var Row in datos)
                             {
                                 Session["UserId"] = Row.UserId.ToString();
                                 Session["username"] = Row.UserName.ToString();
                                 Session["Rolname"] = Row.Rolname.ToString();
                                 Session.Timeout = 30;

                                 string idcuenta = string.Empty;
                                 string nombreusuario = string.Empty;

                                 var querycuenta = from usrcnt in db.cnt03_cuenta_usuario
                                                   join usr2 in db.AspNetUsers on usrcnt.UserId equals usr2.Id
                                                   join usrinfo in db.usr01_infopersonal on usr2.Id equals usrinfo.UserId
                                                   join cnt in db.cnt01_cuenta on usrcnt.cnt01_id equals cnt.cnt01_id
                                                   where usr2.Id == Row.UserId.ToString()
                                                   select new
                                                   {
                                                       id_cuenta = usrcnt.cnt01_id,
                                                       nombreusuario = usrinfo.usr01_nombre +"  "+ usrinfo.usr01_apellido 
                                                   };
                                 if (querycuenta.Count() > 0)
                                 {
                                     var datoscuenta = querycuenta.ToList();
                                     foreach (var Rowcuenta in datoscuenta)
                                     {
                                         idcuenta = Rowcuenta.id_cuenta.ToString();
                                         nombreusuario = Rowcuenta.nombreusuario.ToString();
                                     }
                                 }
                                 Session["CuentaId"] = idcuenta;
                                 Session["nmbrusr"] = nombreusuario;

                                 if (idcuenta != string.Empty)
                                 {
                                     switch (Row.Rolname.ToString().ToLower())
                                     {
                                         case "admin":

                                             Session["layout"] = "~/Views/Shared/_LayoutAdmin.cshtml";
                                             urlretorno = "~/portal/admin/index";
                                             break;
                                         case "manager":
                                             Session["layout"] = "~/Views/Shared/_LayoutManager.cshtml";
                                             urlretorno = "~/portal/manager/index";
                                             break;
                                         case "user":
                                             Session["layout"] = "~/Views/Shared/_LayoutUser.cshtml";
                                             urlretorno = "~/portal/default/index";
                                             break;
                                         default:
                                             Session["layout"] = "~/Views/Shared/_LayoutUser.cshtml";
                                             urlretorno = "~/portal/default/index";
                                             break;
                                     }
                                 }
                                 else
                                 {
                                     Session["layout"] = "";
                                     urlretorno = "~/completarinformacion/InformacionUsuario/index";
                                 }


                             }
                         }

                        return RedirectToLocal(urlretorno);
                    }
                    else
                    {
                        return RedirectToLocal(returnUrl);
                    }
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Intento de inicio de sesión no válido.");
                    return View(model);
            }
        }

        //
        // GET: /Users/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Requerir que el usuario haya iniciado sesión con nombre de usuario y contraseña o inicio de sesión externo
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Users/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // El código siguiente protege de los ataques por fuerza bruta a los códigos de dos factores. 
            // Si un usuario introduce códigos incorrectos durante un intervalo especificado de tiempo, la cuenta del usuario 
            // se bloqueará durante un período de tiempo especificado. 
            // Puede configurar el bloqueo de la cuenta en IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Código no válido.");
                    return View(model);
            }
        }

        //
        // GET: /Users/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Users/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await this.UserManager.AddToRoleAsync(user.Id, "User");
                    ModelMK db = new ModelMK();

                    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action(
                         "ConfirmEmail", "Cuentas", 
                         new { userId = user.Id, code = code }, 
                         protocol: Request.Url.Scheme);

                     var message = new MailMessage()
                     {
                         Subject = "Bienvenido a MailCreativo",
                         IsBodyHtml = true,
                     };

                    message.To.Add(model.Email);
                    
                    string textplain = "Para confirmar la cuenta, haga clic " + callbackUrl ;
                    string html = string.Format("<table border='0' cellspacing='0' cellpadding='0' align='left' width='100%' style='width:100.0%;border-collapse:collapse;margin-left:-2.25pt;margin-right:-2.25pt;padding:0px 0px 0px 0px'><tr><td valign='top' style='padding:0px 0px 30.0px 0px' id='bodyContent'><h1 align='center' style='text-align:center;line-height:31.5pt;'>&nbsp; </h1><h1 align='center' style='text-align:center;line-height:31.5pt;'><span style='font-size:20px;font-family: Helvetica Neue;color:#626262;text-decoration:none;'>Bienvenido, {0}</span> </h1></td></tr><tr><td valign='top' style='padding:0px 0px 3.75px 0px'><div align='center'><table border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;border-collapse:collapse;padding-alt:0px 0px 0px 0px'><tr><td style='padding:0px 0px 0px 0px'><div align='center'><table border='0' cellspacing='0' cellpadding='0' width='200' style='width:150.0pt;border-collapse:collapse;padding:0px 0px 0px 0px'><tr><td valign='top' style='background:#52BAD5;padding:15.0px 15.0px 15.0px 15.0px'><p align='center' style='text-align:center'> <span style='font-family:Times New Roman'> <a href='{1}' ='_blank' style='border-radius:3px;display:inline-block'> <b> <span style='font-family:Helvetica Neue; color:white;letter-spacing:.25pt;background:#52BAD5'>Activar Cuenta</span></b></a> </td></tr></table></div></td></tr></table></div></td></tr><tr><td valign='top' style='padding:0px 0px 30.0px 0px'><p align='center' style='margin:0px;margin-bottom:.0001pt;text-align:center;line-height:31.5pt;'> <span style='font-size:10.5pt;font-family:Helvetica Neue;color:#929292'>(Solo para confirmar que eres tu)</span></p></td></tr></table>", model.Email, callbackUrl);

                    decimal dcm_tiponotificacion = 0;

                    
                    var query = from tiponotificacion in db.ntf02_tiponotificacioncorreo
                                where tiponotificacion.ntf02_nombre  == "notificación"
                                select new
                                {
                                    llaveNotificacion = tiponotificacion.ntf02_id
                                };

                    if (query.Count() > 0)
                    {
                        var datos = query.ToList();
                        foreach (var Row in datos)
                        {
                            dcm_tiponotificacion = (decimal)Row.llaveNotificacion;
                        }
                    }

                    /*
                    var mail = mkemail.Base_Mail_Cliente(message, html, textplain, user.Id, dcm_tiponotificacion);
                    */

                    //await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);
                    
                    // Para obtener más información sobre cómo habilitar la confirmación de cuenta y el restablecimiento de contraseña, visite http://go.microsoft.com/fwlink/?LinkID=320771
                    // Enviar correo electrónico con este vínculo
                    
                    return RedirectToAction("registrofinalizado", "cuentas");
                }
                AddErrors(result);
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        //
        // GET: /Users/Register
        [AllowAnonymous]
        public ActionResult registrofinalizado()
        {
            return View();
        }


        
        //
        // GET: /Users/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {

            ModelMK db = new ModelMK();
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);

            if (result.Succeeded)
            {
                
                return View("ConfirmEmail");

            }
            else 
            {
                var dato = result;
            }
            return RedirectToAction("index", "InformacionUsuario", new { area = "completarinformacion" });
        }

        //
        // GET: /Users/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Users/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // No revelar que el usuario no existe o que no está confirmado
                    return View("ForgotPasswordConfirmation");
                }

                // Para obtener más información sobre cómo habilitar la confirmación de cuenta y el restablecimiento de contraseña, visite http://go.microsoft.com/fwlink/?LinkID=320771
                // Enviar correo electrónico con este vínculo
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Users", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Restablecer contraseña", "Para restablecer la contraseña, haga clic <a href=\"" + callbackUrl + "\">aquí</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Users");
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        //
        // GET: /Users/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Users/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Users/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // No revelar que el usuario no existe
                return RedirectToAction("ResetPasswordConfirmation", "Users");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Users");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Users/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Users/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Solicitar redireccionamiento al proveedor de inicio de sesión externo
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Users", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Users/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Users/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generar el token y enviarlo
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Users/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Si el usuario ya tiene un inicio de sesión, iniciar sesión del usuario con este proveedor de inicio de sesión externo
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // Si el usuario no tiene ninguna cuenta, solicitar que cree una
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Users/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Obtener datos del usuario del proveedor de inicio de sesión externo
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Users/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Users/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Aplicaciones auxiliares
        // Se usa para la protección XSRF al agregar inicios de sesión externos
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}