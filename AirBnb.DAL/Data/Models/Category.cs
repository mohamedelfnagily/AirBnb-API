using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Data.Models
{
    public class Category
    {
        public Category()
        {
            Properties = new HashSet<Property>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; } = "";
        public ICollection<Property> Properties { get; set; }
    }
}
