using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.DTOs.CategoryDTOs
{
    public class CategoryUpdateDTO
    {
        public Guid id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; } = "";
        [Required]
        [StringLength(300)]
        public string? Description { get; set; } = "";
        // public ICollection<Property> Properties { get; set; }
    }
}
