using System.Collections.Generic;

namespace ProductAvailability.Core
{
    public interface IMusicContractService
    {
        List<ActiveContract> GetActiveList(List<DistributionPartner> partners, System.DateTime fromDate, string partner);
    }
}