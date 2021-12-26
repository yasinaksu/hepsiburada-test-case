using Business.Abstract.Mapper;
using Entities.Domain;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Mapper
{
    public class CampaignMapper : ICampaignMapper
    {
        public Campaign MapToCampaign(CampaignDto campaignDto)
        {
            var campaign = new Campaign
            {
                Duration = campaignDto.Duration,
                Name = campaignDto.Name,
                PriceManipulationLimit = campaignDto.PriceManipulationLimit,
                ProductCode = campaignDto.ProductCode,
                TargetSalesCount = campaignDto.TargetSalesCount,
                IsActive = campaignDto.IsActive,
                StartTime = campaignDto.StartTime                
            };
            return campaign;
        }

        public CampaignDto MapToDto(Campaign campaign)
        {
            if (campaign == null)
            {
                return null;
            }
            var campaignDto = new CampaignDto
            {
                Duration = campaign.Duration,
                Name = campaign.Name,
                PriceManipulationLimit = campaign.PriceManipulationLimit,
                ProductCode = campaign.ProductCode,
                TargetSalesCount = campaign.TargetSalesCount,
                EndTime = campaign.EndTime,
                IsActive = campaign.IsActive,
                StartTime = campaign.StartTime                
            };
            return campaignDto;
        }

        public List<CampaignDto> MapToDtoList(List<Campaign> campaignList)
        {
            var campaignDtoList = new List<CampaignDto>();
            foreach (var campaign in campaignList)
            {
                var campaignDto = this.MapToDto(campaign);
                campaignDtoList.Add(campaignDto);
            }
            return campaignDtoList;
        }
    }
}
