using System.Collections.Generic;

namespace ProductAvailability.Core
{
    public interface IMusicContractsRepo
    {
        List<MusicContract> GetList(List<DistributionPartner> partners);
    }
}
