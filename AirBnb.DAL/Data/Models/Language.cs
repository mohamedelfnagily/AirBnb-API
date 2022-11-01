using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.DAL.Data.Models
{
    public class Language
    {
        public Language()
        {
            Users = new HashSet<User>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public ICollection<User> Users { get; set; }
    }
}
