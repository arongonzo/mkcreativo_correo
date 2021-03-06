﻿using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _pln02_tipoplan
    {
        [Key]
        [Display(Name = "Tipo de Plan")]
        public decimal pln02_id { get; set; }

        [Display(Name = "Tipo Cobro")]
        public decimal pln03_id { get; set; }

        [Display(Name="Tipo Cobro")]
        public string pln03_nombre { get; set; }

        [Display(Name = "Tipo de Plan")]
        public string pln02_nombre { get; set; }

        [Display(Name="Descripción")]
        public string pln02_descripcion { get; set; }

        public int? pln02_estado { get; set; }

        public DateTime? pln02_ultimaactualizacion { get; set; }

        public DateTime? pln02_fechacreacion { get; set; }

        [UIHint("TipoCobro")]
        public _pln03_tipocobro _tipocobro
        {
            get;
            set;
        }


    }
}