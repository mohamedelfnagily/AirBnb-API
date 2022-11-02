using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.DTOs.CategoryDTOs
{
    public class CategoryReadDTO
    {
        public string Name { get; set; } = "";
        public string? Description { get; set; } = "";
        public string Errors { get; set; } = "";
        public string URL { get; set; }
    }
}
