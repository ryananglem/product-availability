using Ninject;
using ProductAvailability.Core;

namespace ProductAvailability
{
    class Program
    {
        static void Main(string[] args)
        {
            // bind dependencies
            IKernel kernel = new StandardKernel(new ProductAvailablityModule());

            var console = kernel.Get<ConsoleWriter>();
            var dpService = kernel.Get<DistributionPartnerService>();
            var dateService = kernel.Get<DateService>();
            var mcService = kernel.Get<IMusicContractService>();

            var bootStrapper = new Bootstrapper(console, dpService, dateService, mcService);
            bootStrapper.Start(args);                           
        }
    }
}
