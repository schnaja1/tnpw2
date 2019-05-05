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
    public class PSC : IEntity
    {
      

        public virtual int Id { get; set; }

        [Range(0,int.MaxValue,ErrorMessage = "Zadaná hodnota neodpovídá PSČ")]
   //     [StringLength(5, ErrorMessage = "Zadaný údaj nemá délku jako psč")]
        [Required(ErrorMessage = "Psč je vyžadováno")]
        public virtual int psc { get; set; }

    }
}
