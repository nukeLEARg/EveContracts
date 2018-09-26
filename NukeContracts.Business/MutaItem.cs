using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NukeESI;

namespace NukeContracts.Business
{
    public class MutaItem
    {
        public ContractContents contents { get; set; }
        public TypeCall type { get; set; }
        public MutaCall muta { get; set; }
    }
}
