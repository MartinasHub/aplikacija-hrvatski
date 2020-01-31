using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aplikacija.Models
{
    public class ZaposleniciPrijava
    {
        [Required(ErrorMessage = "Korisničko ime je obavezno")]
        [Display(Name = "Korisnik:")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Lozinka je obavezna")]
        [Display(Name = "Lozinka:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Zapamti me")]
        public bool RememberMe { get; set; }
    }
}