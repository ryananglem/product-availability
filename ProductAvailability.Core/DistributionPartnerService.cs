using System.Collections.Generic;

namespace ProductAvailability.Core
{
    public class DistributionPartnerService : IDistributionPartnerService
    {
        private IDistributionPartnerRepo _repo;

        public DistributionPartnerService(IDistributionPartnerRepo repo)
        {
            _repo = repo;
        }

        public List<DistributionPartner> GetList()
        {
            return _repo.GetDistributionPartners();
        }
    }
}
