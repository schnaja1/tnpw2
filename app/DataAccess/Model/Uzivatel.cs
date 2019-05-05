using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccess.Model
{
    public class Uzivatel : IEntity
    {
        public virtual int Id { get; set; }

        [StringLength(40, ErrorMessage = "Zadaný údaj je příliš dlouhý")]
        [EmailAddress(ErrorMessage ="zadejte emailovou adresu")]
        [Required(ErrorMessage = "Login je vyžadován")]
        [Remote("doesUserNameExist", "Registrace", HttpMethod = "POST", ErrorMessage = "Uživatel s tímto loginem již existuje.")]
        public virtual string login { get; set; }

        [StringLength(100, ErrorMessage = "Zadaný údaj je příliš dlouhý")]
        [Required(ErrorMessage = "Heslo je vyžadováno")]
        public virtual string heslo { get; set; }

        [StringLength(40, ErrorMessage = "Zadaný údaj je příliš dlouhý")]
        [Required(ErrorMessage = "Jméno je vyžadováno")]
        public virtual string jmeno { get; set; }

        [StringLength(40, ErrorMessage = "Zadaný údaj je příliš dlouhý")]
        [Required(ErrorMessage = "Příjmení je vyžadováno")]
        public virtual string prijmeni { get; set; }

        [StringLength(14, ErrorMessage = "Zadaný údaj je příliš dlouhý")]
        [Required(ErrorMessage = "Telefon je vyžadován")]
        [DataType(DataType.PhoneNumber)]
        public virtual string telefon { get; set; }

        public virtual bool novinky { get; set; }

        public virtual UzivatelskaPrava prava { get; set; }

        public virtual Adresa adresa { get; set; }

    }
}
