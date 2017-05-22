
namespace ProductAvailability.Core
{
    public class DistributionPartner
    {
        public DistributionPartner(string partner, string usage)
        {
            Partner = partner;
            Usage = usage;
        }
        public string Partner { get; }
        public string Usage { get; }
    }
}
