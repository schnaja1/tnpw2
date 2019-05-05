using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class ZpusobStravovani : IEntity
    {
        public virtual int Id { get; set; }

        [StringLength(30, ErrorMessage = "Zadaný údaj je příliš dlouhý")]
        [Required(ErrorMessage = "Název je vyžadován")]
        public virtual string nazev { get; set; }

        [Required(ErrorMessage = "Popis je vyžadován")]
        public virtual string popis { get; set; }
    }
}
