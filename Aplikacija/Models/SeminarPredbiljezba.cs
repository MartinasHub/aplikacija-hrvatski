using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aplikacija.Models
{
    public class SeminarPredbiljezba : Predbiljezba
    {
        public string NazivSeminara { get; set; }
        [Display(Name = "Naziv")]
        public string Naziv { get; set; }
        [Display(Name = "Opis")]
        public string Opis { get; set; }
        public bool Popunjen { get; set; }
        public string Predavač { get; set; }
    }
}