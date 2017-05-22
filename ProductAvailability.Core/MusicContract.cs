using System;
using System.Collections.Generic;

namespace ProductAvailability.Core
{
    public class MusicContract
    {
        public MusicContract(string artist, string title, List<DistributionPartner> usages, DateTime startDate, DateTime? endDate)
        {
            Artist = artist;
            Title = title;
            Usages = usages ?? new List<DistributionPartner>();
            StartDate = startDate;
            EndDate = endDate;
        }
        public String Artist { get; }
        public String Title { get; }
        public List<DistributionPartner>  Usages { get; }
        public DateTime StartDate { get; }
        public DateTime? EndDate { get; }
    }
}
