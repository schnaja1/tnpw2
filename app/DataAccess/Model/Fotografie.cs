using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Fotografie : IEntity
    {
        public virtual int Id { get; set; }


        [StringLength(50, ErrorMessage = "Zadaný údaj je příliš dlouhý")]
        [Required(ErrorMessage = "Popisek je vyžadován")]
        public virtual string popisek { get; set; }

        [Required(ErrorMessage = "Fotografie je vyžadována")]
        public virtual string fotografie { get; set; }

        [Required(ErrorMessage = "Náhled je vyžadován")]
        public virtual string nahled { get; set; }

        public virtual Hotel hotel { get; set;}
    }
    }
