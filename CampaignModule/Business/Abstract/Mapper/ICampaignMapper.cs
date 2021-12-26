using Entities.Domain;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Mapper
{
    public interface ICampaignMapper
    {
        CampaignDto MapToDto(Campaign campaign);
        Campaign MapToCampaign(CampaignDto campaignDto);
        List<CampaignDto> MapToDtoList(List<Campaign> campaignList);
    }
}
