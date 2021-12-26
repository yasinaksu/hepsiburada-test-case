using Business.Abstract.CommandHandler;
using Business.Abstract.Service;
using System;

namespace Business.Concrete.CommandHandlers
{
    public class GetCampaignInfoCommandHandler : IObserverCommandHandler
    {
        private readonly ICampaignService _campaignService;
        public GetCampaignInfoCommandHandler(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        public void Execute(string command)
        {
            if (!command.Contains("get_campaign_info"))
            {
                return;
            }
            var name = this.ParseCommand(command);
            var campaign = _campaignService.GetCampaignByName(name);
            this.SendMessage(campaign);
        }

        private void SendMessage(Entities.Dtos.CampaignDto campaign)
        {
            var statusText = campaign.IsActive ? "Active" : "Passive";
            var message = $"Campaign {campaign.Name} info; Status {statusText}, Target Sales {campaign.TargetSalesCount}";
            Console.WriteLine(message);
        }

        private string ParseCommand(string command)
        {
            var commandWords = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var name = commandWords[1];
            return name;
        }
    }
}
