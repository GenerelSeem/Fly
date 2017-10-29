using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Model
{

    public class Flyreise
    {
        [Display(Name = "FlyreiseId")]
        [Required(ErrorMessage = "Flyreisen må ha en identifikasjon")]
        public int FlyreiseId { get; set; }
        [Display(Name = "fraBy")]
        [Required(ErrorMessage = "Du må reise fra et sted")]
        public string fraBy { get; set; }
        [Display(Name = "tilBy")]
        [Required(ErrorMessage = "Du må reise til et sted")]
        public string tilBy { get; set; }
        [Display(Name = "tid")]
        [Required(ErrorMessage = "Du må ha en reisetid")]
        public string tid { get; set; }
        [Display(Name = "pris")]
        [Required(ErrorMessage = "Reisen må ha en pris")]
        public string pris { get; set; }
    }

    public class Kunde
    {
        [Display(Name = "KundeId")]
        [Required(ErrorMessage = "Kunden må ha et indentifikasjonsnummer")]
        public int KundeId { get; set; }
        [Display(Name = "Fornavn")]
        [Required(ErrorMessage = "Du må ha et fornavn")]
        public string Fornavn { get; set; }
        [Display(Name = "Etternavn")]
        [Required(ErrorMessage = "Du må ha et etternavn")]
        public string Etternavn { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Du må ha ")]
        public string Email { get; set; }
    }
    public class Billett
    {
        [Display(Name = "BillettId")]
        [Required(ErrorMessage = "Billetten må ha en identifikasjon")]
        public int BillettId { get; set; }
        [Display(Name = "Reisedato")]
        [Required(ErrorMessage = "Du må ha en reisedato")]
        public DateTime ReiseDato { get; set; }

        // Foreign keys
        public int FlyreiseId { get; set; }
        public Flyreise Flyreise { get; set; }

        public int KundeId { get; set; }
        public Kunde Kunde { get; set; }
    }

    public class Admin
    {
        [Display(Name = "AdminId")]
        [Required(ErrorMessage = "Admin må ha et identifikasjonnummer")]
        public int AdminId { get; set; }
        [Display(Name = "Bruker")]
        [Required(ErrorMessage = "Må ha et brukernavn")]
        public string Bruker { get; set; }
        [Display(Name = "Passord")]
        [Required(ErrorMessage = "Må ha et passord")]
        public string Passord { get; set; }
    }
}