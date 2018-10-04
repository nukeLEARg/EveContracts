using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeContracts.Business.Models
{
    public class Filter
    {
        public decimal Price { get; set; }
        public string Type { get; set; }
        public List<int> Items { get; set; }
        public List<int> dogmas { get; set; }
        
        public Filter()
        {
        }
    }
}
