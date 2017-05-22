using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductAvailability.Core
{
    public class MusicContractService : IMusicContractService
    {
        private IMusicContractsRepo _repo;

        public MusicContractService(IMusicContractsRepo repo)
        {
            _repo = repo;
        }

        public List<ActiveContract> GetActiveList(List<DistributionPartner> partners, DateTime theDate, string partner)
        {
            var contracts =  _repo.GetList(partners);

            return contracts
                        .Where(x => x.StartDate < theDate)                     
                        .Where(u => u.Usages.Any(p => p.Partner == partner))
                        .Select(n => new ActiveContract
                                        {
                                            Artist = n.Artist,
                                            Title = n.Title,
                                            Usage = n.Usages.Single(x => x.Partner==partner).Usage,
                                            StartDate = n.StartDate.ToLongDateString(),
                                            EndDate = n.EndDate==null ? "" : Convert.ToDateTime(n.EndDate).ToLongDateString()
                        })
                        .ToList();
            
        }

    }
}
