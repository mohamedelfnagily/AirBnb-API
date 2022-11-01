using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Data.Models
{
    public class PropertyPicture
    {
        public Guid Id { get; set; }
        public string URL { get; set; } = "";
        [ForeignKey("Property")]
        public Guid PropertyId { get; set; }
        public Property Property { get; set; } = null!;
    }
}
