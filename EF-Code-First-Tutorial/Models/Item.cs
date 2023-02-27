using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EF_Code_First_Tutorial.Models
{
    public class Item
    {
        public int Id { get; set; }
        [StringLength(40)]
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; } 

        public Item() { }


    }
}
