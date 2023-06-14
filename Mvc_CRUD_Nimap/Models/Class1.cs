using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_CRUD_Nimap.Models
{
    public class Class1
    {
        [Key]
        [Required]
        [DisplayName("ID")]
        public int Id { get; set; }
        [Required]
        [DisplayName("CategoryId")]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("CategoryName")]
        public string CategoryName { get; set; }


    }
}