using Business.Abstract.CommandHandler;
using Business.Abstract.Service;
using Business.Concrete.PriceChangeAlgorithm;
using Entities.Requests;
using System;

namespace Business.Concrete.CommandHandlers
{
    public class IncreaseTimeCommandHandler : IObserverCommandHandler
    {
        private readonly ITimeService _timeService;
        private readonly ICampaignService _campaignService;
        private readonly IProductService _productService;
        public IncreaseTimeCommandHandler(ITimeService timeService, ICampaignService campaignService, IProductService productService)
        {
            _timeService = timeService;
            _campaignService = campaignService;
            _productService = productService;
        }

        public void Execute(string command)
        {
            if (!command.Contains("increase_time"))
            {
                return;
            }
            var hour = this.ParseCommand(command);
            _timeService.IncreaseTime(hour);
            _productService.DecreaseAllPromotionalProductPrice(hour);
            _campaignService.SetPassiveAllExpiredCampaign();
            var message = $"Time is {_timeService.GetCurrentTime().ToString("HH:mm")}";
            Console.WriteLine(message);
        }

        private int ParseCommand(string command)
        {
            var commandWords = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var hour = Convert.ToInt32(commandWords[1]);
            return hour;
        }       
    }
}
