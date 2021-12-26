using Entities.Domain;
using Entities.Dtos;
using Entities.Results;
using System;
using System.Collections.Generic;

namespace Business.Abstract.Service
{
    public interface ICampaignService
    {
        Result Add(CampaignDto campaignDto);
        CampaignDto GetCampaignByName(string name);
        List<CampaignDto> GetAll();
        CampaignDto GetCurrentCampaignByProductCode(string productCode, DateTime currentTime);
        Result SetPassiveAllExpiredCampaign();
        List<CampaignDto> GetAllCurrentCampaigns();
    }
}
