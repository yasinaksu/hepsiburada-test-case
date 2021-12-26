using Business.Abstract.CommandHandler;
using Business.Abstract.Service;
using Entities.Domain;
using Entities.Dtos;
using System;

namespace Business.Concrete.CommandHandlers
{
    public class CreateCampaignCommandHandler : IObserverCommandHandler
    {
        private readonly ICampaignService _campaignService;
        private readonly ITimeService _timeService;
        private readonly IProductService _productService;
        public CreateCampaignCommandHandler(ICampaignService campaignService, ITimeService timeService, IProductService productService)
        {
            _campaignService = campaignService;
            _timeService = timeService;
            _productService = productService;
        }

        public void Execute(string command)
        {
            if (!command.Contains("create_campaign"))
            {
                return;
            }
            var campaignDto = this.ParseCommand(command);
            _campaignService.Add(campaignDto);
            _productService.UpdateProductByCampaign(campaignDto);
            this.SendMessage(campaignDto);
            
        }

        private CampaignDto ParseCommand(string command)
        {
            var commandWords = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var campaignDto = new CampaignDto
            {
                Name = commandWords[1],
                ProductCode = commandWords[2],
                Duration = Convert.ToInt32(commandWords[3]),
                PriceManipulationLimit = Convert.ToInt32(commandWords[4]),
                TargetSalesCount = Convert.ToInt32(commandWords[5]),
                StartTime = _timeService.GetCurrentTime(),
                IsActive = true
            };
            return campaignDto;
        }

        private void SendMessage(CampaignDto campaignDto)
        {
            var message = $"Campaign created; name {campaignDto.Name}, product {campaignDto.ProductCode}, duration {campaignDto.Duration}, limit {campaignDto.PriceManipulationLimit}, target sales count {campaignDto.TargetSalesCount}";
            Console.WriteLine(message);
        }
    }
}
