using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Stat : IEntity
    {
        public virtual int Id { get; set; }

        [StringLength(40, ErrorMessage = "Zadaný údaj je příliš dlouhý")]
        [Required(ErrorMessage = "Název je vyžadován")]
        public virtual string jmeno { get; set; }
    }
}
