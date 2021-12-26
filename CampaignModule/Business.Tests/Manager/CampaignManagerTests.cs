using Business.Abstract.Mapper;
using Business.Abstract.Service;
using Business.Concrete.Managers;
using DataAccess.Abstract;
using Entities.Domain;
using Entities.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests.Manager
{
    [TestClass]
    public class CampaignManagerTests
    {
        Mock<ICampaignRepository> _campaignRepository;
        Mock<ICampaignMapper> _campaignMapper;
        Mock<ITimeService> _timeService;
        ICampaignService _campaignService;

        [TestInitialize]
        public void Initialize()
        {
            _campaignRepository = new Mock<ICampaignRepository>();
            _campaignMapper = new Mock<ICampaignMapper>();
            _timeService = new Mock<ITimeService>();
            _campaignService = new CampaignManager(
                _campaignRepository.Object,
                _campaignMapper.Object,
                _timeService.Object
            );
        }

        [TestMethod]
        public void AddTest()
        {
            var now = DateTime.Now;
            var campaignDto = new CampaignDto
            {
                Duration = 10,
                EndTime = now.AddHours(10),
                IsActive = true,
                Name = "C1",
                PriceManipulationLimit = 10,
                ProductCode = "P1",
                StartTime = now,
                TargetSalesCount = 100
            };

            var result = _campaignService.Add(campaignDto);
            bool expected = true;
            Assert.AreEqual(expected, result.IsSuccess);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var campaingList = new List<Campaign>();
            for (int i = 0; i < 5; i++)
            {
                var campaign = new Campaign();
                campaingList.Add(campaign);
            }
            _campaignRepository.Setup(x => x.GetAll()).Returns(campaingList);
            var campaignDtoList = new List<CampaignDto>();
            for (int i = 0; i < 5; i++)
            {
                var campaignDto = new CampaignDto();
                campaignDtoList.Add(campaignDto);
            }
            _campaignMapper.Setup(x => x.MapToDtoList(It.IsAny<List<Campaign>>())).Returns(campaignDtoList);
            

            var result = _campaignService.GetAll();
            int expectedCount = 5;
            Assert.AreEqual(expectedCount, result.Count);
        }

        [TestMethod]
        public void GetCampaignByNameTest()
        {
            var campaignName = "C1";
            var campaign = new Campaign { Name = campaignName };
            _campaignRepository.Setup(x => x.GetCampaignByName(It.IsAny<string>())).Returns(campaign);
            var campaignDto = new CampaignDto { Name = campaignName };
            _campaignMapper.Setup(x => x.MapToDto(It.IsAny<Campaign>())).Returns(campaignDto);
            
            var result = _campaignService.GetCampaignByName(campaignName);
            var expectedCampaignName = campaignName;
            Assert.AreEqual(expectedCampaignName, result.Name);
        }

        [TestMethod]
        public void GetAllCurrentCampaignsTest()
        {
            var campaingList = new List<Campaign>();
            for (int i = 0; i < 5; i++)
            {
                var campaign = new Campaign();
                campaingList.Add(campaign);
            }
            _campaignRepository.Setup(x => x.GetAllCurrentCampaigns(It.IsAny<DateTime>())).Returns(campaingList);
            var campaignDtoList = new List<CampaignDto>();
            for (int i = 0; i < 5; i++)
            {
                var campaignDto = new CampaignDto();
                campaignDtoList.Add(campaignDto);
            }
            _campaignMapper.Setup(x => x.MapToDtoList(It.IsAny<List<Campaign>>())).Returns(campaignDtoList);


            var result = _campaignService.GetAllCurrentCampaigns();
            int expectedCount = 5;
            Assert.AreEqual(expectedCount, result.Count);
        }

        [TestMethod]
        public void GetCurrentCampaignByProductCodeTest()
        {
            var campaignName = "C1";
            var productCode = "P1";
            var currentTime = DateTime.Now;
            var campaign = new Campaign { Name = campaignName, ProductCode = productCode };
            _campaignRepository.Setup(x => x.GetCurrentCampaignByProductCode(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(campaign);
            var campaignDto = new CampaignDto { Name = campaignName, ProductCode = productCode };
            _campaignMapper.Setup(x => x.MapToDto(It.IsAny<Campaign>())).Returns(campaignDto);

            var result = _campaignService.GetCurrentCampaignByProductCode(productCode, currentTime);
            var expectedCampaignName = campaignName;
            Assert.AreEqual(expectedCampaignName, result.Name);
        }

        [TestMethod]
        public void SetPassiveAllExpiredCampaignTest()
        {
            var campaingList = new List<Campaign>();
            for (int i = 0; i < 5; i++)
            {
                var campaign = new Campaign();
                campaingList.Add(campaign);
            }
            _campaignRepository.Setup(x => x.FindAllExpiredCampaigns(It.IsAny<DateTime>())).Returns(campaingList);          


            var result = _campaignService.SetPassiveAllExpiredCampaign();
            var expectedResult = true;
            Assert.AreEqual(expectedResult, result.IsSuccess);
        }
    }
}
