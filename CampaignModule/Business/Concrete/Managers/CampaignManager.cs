using Business.Abstract.Mapper;
using Business.Abstract.Service;
using DataAccess;
using DataAccess.Abstract;
using Entities.Domain;
using Entities.Dtos;
using Entities.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete.Managers
{
    public class CampaignManager : ICampaignService
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly ICampaignMapper _campaignMapper;
        private readonly ITimeService _timeService;
        public CampaignManager(ICampaignRepository campaignRepository, ICampaignMapper campaignMapper, ITimeService timeService)
        {
            _campaignRepository = campaignRepository;
            _campaignMapper = campaignMapper;
            _timeService = timeService;
        }

        public Result Add(CampaignDto campaignDto)
        {
            var campaign = _campaignMapper.MapToCampaign(campaignDto);
            _campaignRepository.Add(campaign);
            return Result.Ok();
        }


        public List<CampaignDto> GetAll()
        {
            var campaigns = _campaignRepository.GetAll();
            var campaignDtos = _campaignMapper.MapToDtoList(campaigns);
            return campaignDtos;
        }

        public List<CampaignDto> GetAllCurrentCampaigns()
        {
            var activeCampaigns = _campaignRepository.GetAllCurrentCampaigns(_timeService.GetCurrentTime());
            return _campaignMapper.MapToDtoList(activeCampaigns);
        }

        public CampaignDto GetCampaignByName(string name)
        {
            var campaign = _campaignRepository.GetCampaignByName(name);
            var campaignDto = _campaignMapper.MapToDto(campaign);
            return campaignDto;
        }

        public CampaignDto GetCurrentCampaignByProductCode(string productCode, DateTime currentTime)
        {
            var campaign = _campaignRepository.GetCurrentCampaignByProductCode(productCode, currentTime);
            var campaignDto = _campaignMapper.MapToDto(campaign);
            return campaignDto;
        }

        public Result SetPassiveAllExpiredCampaign()
        {
            var expiredCampaigns = _campaignRepository.FindAllExpiredCampaigns(_timeService.GetCurrentTime());
            foreach (var expiredCampaign in expiredCampaigns)
            {
                expiredCampaign.IsActive = false;
            }
            return Result.Ok();
        }
    }
}
