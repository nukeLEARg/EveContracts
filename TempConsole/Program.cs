using NukeContracts.Business;
using NukeContracts.Business.Enumerations;
using System.Linq;

namespace TempConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var nuke = new NukeLogic();
            var contracts = nuke.Contracts(Region.TheSpire);
            var x = contracts.FirstOrDefault();
        }
    }
}
