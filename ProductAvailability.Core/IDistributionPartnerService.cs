using System.Collections.Generic;

namespace ProductAvailability.Core
{
    public interface IDistributionPartnerService
    {
        List<DistributionPartner> GetList();
    }
}