using ProductAvailability.Core;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ProductAvailability.FileRepo
{
    public class DistributionPartnerFileRepo : IDistributionPartnerRepo
    {
        private string _fileName;
        
        public DistributionPartnerFileRepo(string fileName)
        {
            _fileName = fileName;
        }

        public List<DistributionPartner> GetDistributionPartners()
        {
            var partners = new List<DistributionPartner>();
            using (var fileStream = new FileStream(_fileName, FileMode.Open, FileAccess.Read))
            {
                var file = new StreamReader(fileStream, System.Text.Encoding.UTF8, true, 128);
                string lineOfText;
                file.ReadLine(); // first line == headers
                while ((lineOfText = file.ReadLine()) != null)
                {
                    partners.Add(Parse(lineOfText));
                }
            }
            return partners;
        }

        public DistributionPartner Parse(string lineOfText)
        {
            var distPartner = lineOfText.Split('|').Select(l => l.Trim()).ToArray(); ;
            if (distPartner.Length != 2)
            {
                throw new System.Exception("incorrect input for distribution partner");
            }
            return new DistributionPartner(distPartner[0], distPartner[1]);
        }
    }
}
