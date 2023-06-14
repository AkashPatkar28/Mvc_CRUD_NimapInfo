using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_CRUD_Nimap.Models
{
    public class Product
    {
        [Key]
        [Required]
        [DisplayName("ID")]
        public int Id { get; set; }

        [Required]
        [DisplayName("ProductName")]
        public string ProductName { get; set; }

        [Required]
        [DisplayName("ProductId")]
        public int ProductId { get; set; }

        [Required]
        [DisplayName("CategoryId")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Class1 Category { get; set; }

        [Required]
        [DisplayName("CategoryName")]
        public string CategoryName { get; set; }


    }
}