using Business.Abstract.CommandHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Factory
{
    public interface ICommandHandlerFactory
    {
        IObserverCommandHandler CreateCreateCampaignCommandHandler();
        IObserverCommandHandler CreateCreateOrderCommandHandler();
        IObserverCommandHandler CreateCreateProductCommandHandler();
        IObserverCommandHandler CreateGetCampaignInfoCommandHandler();
        IObserverCommandHandler CreateGetProductInfoCommandHandler();
        IObserverCommandHandler CreateIncreaseTimeCommandHandler();
    }
}
