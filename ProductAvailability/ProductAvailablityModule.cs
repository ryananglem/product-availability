using Ninject.Modules;
using ProductAvailability.Core;
using ProductAvailability.FileRepo;

namespace ProductAvailability
{
    class ProductAvailablityModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConsoleWriter>().To<ConsoleWriter>();
            Bind<IDistributionPartnerRepo>().To<DistributionPartnerFileRepo>()                
                .WithConstructorArgument("fileName", "DistributionPartnerContracts.txt");
            Bind<IMusicContractsRepo>().To<MusicContractsFileRepo>()
                .WithConstructorArgument("fileName", "MusicContracts.txt");

            Bind<IDateService>().To<DateService>();
            Bind<IMusicContractService>().To<MusicContractService>();
            Bind<IDistributionPartnerService>().To<DistributionPartnerService>();

        }
    }
}
