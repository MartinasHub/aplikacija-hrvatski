//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aplikacija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Predbiljezba
    {
        public int IdPredbiljezba { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> Datum { get; set; }
        [Required(ErrorMessage = "Ime je obavezno!")]
        [Display(Name = "Ime")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno!")]
        [Display(Name = "Prezime")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Adresa je obavezna!")]
        [Display(Name = "Adresa")]
        public string Adresa { get; set; }
        [Required(ErrorMessage = "E-mail je obavezan!")]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefon je obavezan!")]
        [Display(Name = "Telefon")]
        public string Telefon { get; set; }
        public int IdSeminar { get; set; }
        public string Status { get; set; }

        public virtual Seminar Seminar { get; set; }
    }
}
