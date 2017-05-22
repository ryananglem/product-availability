using ProductAvailability.Core;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ProductAvailability.FileRepo
{
    public class MusicContractsFileRepo : IMusicContractsRepo
    {
        private string _fileName;
        private IDateService _dateService;

        public MusicContractsFileRepo(string fileName, IDateService dateService)
        {
            _fileName = fileName;
            _dateService = dateService;
        }

        public List<MusicContract> GetList(List<DistributionPartner> partners)
        {
            var contracts = new List<MusicContract>();
            using (var fileStream = new FileStream(_fileName, FileMode.Open, FileAccess.Read)) { 

                var file = new StreamReader(fileStream, System.Text.Encoding.UTF8, true, 128);
                string lineOfText;
                file.ReadLine(); // first line == headers
                while ((lineOfText = file.ReadLine()) != null)
                {
                    contracts.Add(Parse(lineOfText, partners));
                }
             }
            return contracts;        
        }

        public MusicContract Parse(string lineOfText, List<DistributionPartner> allPartners)
        {
            var contract = lineOfText.Split('|').Select(l => l.Trim()).ToArray(); 
            if (contract.Length != 5)
            {
                throw new Exception("incorrect input format for music contract");
            }            
            var partners = ParsePartnerList(contract[2], allPartners);
            var endDate = ParseEndDate(contract[4]);

            return new MusicContract(
                    contract[0], 
                    contract[1], 
                    partners,
                    _dateService.ParseLongDateFormat(contract[3]), 
                    endDate);
        }

        public List<DistributionPartner> ParsePartnerList(string textlist, List<DistributionPartner> all)
        {             
            var partnerList = textlist.Split(',').Select(p => p.Trim()).ToArray();            
            return all.Where(p => partnerList.Contains(p.Usage)).ToList();
        }

        public DateTime? ParseEndDate(string date)
        {
            DateTime? endDate;
            if (date == string.Empty)
                endDate = null;
            else
                endDate = _dateService.ParseLongDateFormat(date);

            return endDate;
        }
    }
}
