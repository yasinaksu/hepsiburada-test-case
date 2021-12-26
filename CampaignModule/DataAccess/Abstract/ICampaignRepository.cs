using Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICampaignRepository
    {
        void Add(Campaign campaign);
        Campaign GetCampaignByName(string name);
        List<Campaign> GetAll();
        Campaign GetCurrentCampaignByProductCode(string productCode, DateTime currentTime);
        List<Campaign> FindAllExpiredCampaigns(DateTime currentTime);
        List<Campaign> GetAllCurrentCampaigns(DateTime currentTime);
    }
}
