using System.Collections.Generic;

namespace ProductAvailability.Core
{
    public interface IDistributionPartnerRepo
    {
        List<DistributionPartner> GetDistributionPartners();
    }
}
