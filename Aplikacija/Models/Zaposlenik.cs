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

    public partial class Zaposlenik
    {
        public int IdZaposlenik { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Korisničko ime je obavezno!")]
        [Display(Name = "Korisnik: ")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Korisničko ime je obavezno!")]
        [Display(Name = "Korisnik: ")]
        public string Password { get; set; }
        [Display(Name = "Zapamti me")]
        public bool RememberMe { get; set; }
    }
}
