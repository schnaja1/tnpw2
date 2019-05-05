using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Zajezd : IEntity
    {
        public virtual int Id { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "zadejte kladné číslo")]
        [Required(ErrorMessage = "Cena je vyžadována")]
        public virtual double cena { get; set; }

        [DataType(DataType.DateTime,ErrorMessage ="Toto není datum")]
        [Required(ErrorMessage = "Termín je vyžadován")]
        public virtual DateTime od { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Toto není datum")]
        [Required(ErrorMessage = "Termín je vyžadován")]
        public virtual DateTime doo { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "zadejte kladné číslo")]
        [Required(ErrorMessage = "kapacita je vyžadována")]
        public virtual int kapacita { get; set; }
        
        public virtual Hotel hotel { get; set; }

        public virtual MoznostiDopravy doprava { get; set; }

    }
}
