using System;
using NukeContracts.Business;
using NukeContracts.Business.Enumerations;
using NukeContracts.Business.Extensions;
using System.Linq;

namespace TempConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var nuke = new NukeLogic();
            Console.WriteLine($"Fetching contracts for region : {Region.TheSpire.DisplayName()}.");
            var contracts = nuke.Contracts(Region.TheSpire);
            var x = contracts.FirstOrDefault();
        }
    }
}
