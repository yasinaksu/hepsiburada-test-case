using DataAccess.Abstract;
using Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly IDbContext _context;
        public CampaignRepository(IDbContext context)
        {
            _context = context;
        }

        public void Add(Campaign campaign)
        {
            _context.Campaigns.Add(campaign);
        }

        public List<Campaign> FindAllExpiredCampaigns(DateTime currentTime)
        {
            return _context.Campaigns.Where(campaign => campaign.EndTime < currentTime && campaign.IsActive).ToList();
        }

        public List<Campaign> GetAll()
        {
            return _context.Campaigns;
        }

        public List<Campaign> GetAllCurrentCampaigns(DateTime currentTime)
        {
            return _context.Campaigns.Where(campaign => campaign.IsActive && campaign.EndTime > currentTime).ToList();
        }

        public Campaign GetCampaignByName(string name)
        {
            return _context.Campaigns.FirstOrDefault(campaign => campaign.Name == name);
        }

        public Campaign GetCurrentCampaignByProductCode(string productCode, DateTime currentTime)
        {
            return _context.Campaigns.FirstOrDefault(campaign => campaign.ProductCode == productCode && campaign.IsActive && campaign.EndTime > currentTime);
        }
    }
}
