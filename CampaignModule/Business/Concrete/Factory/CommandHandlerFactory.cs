using Business.Abstract.CommandHandler;
using Business.Abstract.Factory;
using Business.Concrete.CommandHandlers;
using Business.Concrete.Managers;
using Business.Concrete.Mapper;
using Business.Concrete.PriceChangeAlgorithm;
using DataAccess;
using DataAccess.Concrete;

namespace Business.Concrete.Factory
{
    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly CreateCampaignCommandHandler _createCampaignCommandHandler;
        private readonly CreateOrderCommandHandler _createOrderCommandHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly GetCampaignInfoCommandHandler _getCampaignInfoCommandHandler;
        private readonly GetProductInfoCommandHandler _getProductInfoCommandHandler;
        private readonly IncreaseTimeCommandHandler _increaseTimeCommandHandler;

        public CommandHandlerFactory(CreateCampaignCommandHandler createCampaignCommandHandler, CreateOrderCommandHandler createOrderCommandHandler, CreateProductCommandHandler createProductCommandHandler, GetCampaignInfoCommandHandler getCampaignInfoCommandHandler, GetProductInfoCommandHandler getProductInfoCommandHandler, IncreaseTimeCommandHandler increaseTimeCommandHandler)
        {
            _createCampaignCommandHandler = createCampaignCommandHandler;
            _createOrderCommandHandler = createOrderCommandHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _getCampaignInfoCommandHandler = getCampaignInfoCommandHandler;
            _getProductInfoCommandHandler = getProductInfoCommandHandler;
            _increaseTimeCommandHandler = increaseTimeCommandHandler;
        }

        public IObserverCommandHandler CreateCreateCampaignCommandHandler()
        {
            return _createCampaignCommandHandler;
        }

        public IObserverCommandHandler CreateCreateOrderCommandHandler()
        {
            return _createOrderCommandHandler;
        }

        public IObserverCommandHandler CreateCreateProductCommandHandler()
        {
            return _createProductCommandHandler;
        }

        public IObserverCommandHandler CreateGetCampaignInfoCommandHandler()
        {
            return _getCampaignInfoCommandHandler;
        }

        public IObserverCommandHandler CreateGetProductInfoCommandHandler()
        {
            return _getProductInfoCommandHandler;
        }

        public IObserverCommandHandler CreateIncreaseTimeCommandHandler()
        {
            return _increaseTimeCommandHandler;
        }
    }
}
