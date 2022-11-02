using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.DTOs.PropertyDTOs
{
    public class FilterByPriceDTO
    {
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
    }
}
