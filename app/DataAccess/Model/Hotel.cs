using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Hotel : IEntity
    {
        public virtual int Id { get; set; }

        [StringLength(40, ErrorMessage = "Zadaný údaj je příliš dlouhý")]
        [Required(ErrorMessage = "Název je vyžadován")]
        public virtual string nazev { get; set; }

        [Required(ErrorMessage = "Popis je vyžadován")]
        public virtual string popis { get; set; }

        [EmailAddress(ErrorMessage = "Toto není emailová adresa")]
        [StringLength(50, ErrorMessage = "Zadaný údaj je příliš dlouhý")]
        [Required(ErrorMessage = "Email je vyžadován")]
        public virtual string email { get; set; }

        [Range(0, 5, ErrorMessage = "zadejte číslo od 0 do 5")]
        public virtual int hodnoceni { get; set; }

        public virtual IList<Fotografie> fotky { get; set; }

        public virtual IList<Zajezd> zajezdy { get; set; } 

        public virtual Destinace destinace { get; set; }

        public virtual ZpusobStravovani stravovani { get; set; }

        public virtual Zajezd nejlevnejsiZajezd { get; set; }
    }
}
