using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Rezervace : IEntity
    {

 
        public virtual int Id { get; set; }

        
        public virtual string poznamka { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "zadejte kladné číslo")]
        public virtual int pocetDeti { get; set; }

        public virtual bool zaplaceno { get; set; }

        public virtual Uzivatel uzivatel { get; set; }

        public virtual Zajezd zajezd { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "zadejte kladné číslo")]
        [Required(ErrorMessage = "Počet je vyžadován")]
        public virtual int pocetDospelych { get; set; }

        public virtual double cena() {
            return (zajezd.cena * pocetDospelych) + (pocetDeti * zajezd.cena * 0.5);
        }

    }
}
