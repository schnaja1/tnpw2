using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataAccess.Interface;
namespace DataAccess.Model
{
    public class Adresa : IEntity
    {
        public virtual int Id { get; set; }

        [StringLength(40, ErrorMessage = "Zadaný údaj je příliš dlouhý")]
        [Required(ErrorMessage = "Město je vyžadováno")]
        public virtual string mesto { get; set; }

        [StringLength(40,ErrorMessage ="Zadaný údaj je příliš dlouhý")]
        [Required(ErrorMessage = "Ulice je vyžadována")]
        public virtual string ulice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "zadejte kladné číslo")]
        [Required(ErrorMessage = "Čp je vyžadováno")]
        public virtual int cp { get; set; }

        public virtual PSC psc { get; set;}
    }
}
