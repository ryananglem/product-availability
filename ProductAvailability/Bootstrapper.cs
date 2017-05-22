using ProductAvailability.Core;
using System.Linq;

namespace ProductAvailability
{
    public class Bootstrapper
    {
        private IConsoleWriter _console;
        private IDistributionPartnerService _dpService;
        private IDateService _dateService;
        private IMusicContractService _mcService;

        public Bootstrapper(
                        IConsoleWriter console, 
                        IDistributionPartnerService dpService, 
                        IDateService dateService,
                        IMusicContractService mcService)
        {
            _console = console;
            _dpService = dpService;
            _dateService = dateService;
            _mcService = mcService;
        }

        public void Start(string[] args)
        {   
            if (args.Length != 4)
            {
                throw new System.Exception("invalid arguments. please supply <partner name> and <date> in the format d-nth MMM yyyy");
            }
            var partners = _dpService.GetList();

            if (!partners.Any(x=> x.Partner.ToLower()==args[0].ToLower()))
            {
                throw new System.Exception("please supply a valid partner");
            }
            var date = _dateService.ParseLongDateFormat(args[1] + args[2] + args[3]);

            var activeContracts = _mcService.GetActiveList(partners, date, args[0]);

            foreach (var contract in activeContracts)
            {
                _console.ConsoleWriteLine($"{contract.Artist}|{contract.Title}|{contract.Usage}|{contract.StartDate}|{contract.EndDate}");
            }

            _console.ConsoleWriteLine("Press any key..");
            _console.ConsoleReadKey();
        }
    }
}
