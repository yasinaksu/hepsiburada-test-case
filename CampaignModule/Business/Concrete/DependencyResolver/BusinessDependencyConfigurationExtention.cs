using Business.Abstract.CommandPublisher;
using Business.Abstract.Factory;
using Business.Abstract.Mapper;
using Business.Abstract.PriceChangeAlgorithm;
using Business.Abstract.Service;
using Business.Concrete.CommandHandlers;
using Business.Concrete.CommandPublishers;
using Business.Concrete.Factory;
using Business.Concrete.Managers;
using Business.Concrete.Mapper;
using Business.Concrete.PriceChangeAlgorithm;
using DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.DependencyResolver
{
    public static class BusinessDependencyConfigurationExtention
    {
        public static void AddBusinessDependencyInjectionModule(this IServiceCollection services)
        {
            services.AddSingleton<IDbContext, DbContext>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<ICampaignRepository, CampaignRepository>();

            services.AddSingleton<IProductMapper, ProductMapper>();
            services.AddSingleton<IOrderMapper, OrderMapper>();
            services.AddSingleton<ICampaignMapper, CampaignMapper>();

            services.AddSingleton<IPriceDecreaseStrategy, LineerPriceDecreaseStrategy>();
            services.AddSingleton<IPriceIncreaseStrategy, LineerPriceIncreaseStrategy>();

            services.AddSingleton<IPriceDecreaseContext, PriceDecreaseContext>();
            services.AddSingleton<IPriceIncreaseContext, PriceIncreaseContext>();

            services.AddSingleton<IProductService, ProductManager>();
            services.AddSingleton<IOrderService, OrderManager>();
            services.AddSingleton<ICampaignService, CampaignManager>();
            services.AddSingleton<ITimeService, TimeManager>();

            services.AddSingleton<CreateCampaignCommandHandler, CreateCampaignCommandHandler>();
            services.AddSingleton<CreateOrderCommandHandler, CreateOrderCommandHandler>();
            services.AddSingleton<CreateProductCommandHandler, CreateProductCommandHandler>();
            services.AddSingleton<GetCampaignInfoCommandHandler, GetCampaignInfoCommandHandler>();
            services.AddSingleton<GetProductInfoCommandHandler, GetProductInfoCommandHandler>();
            services.AddSingleton<IncreaseTimeCommandHandler, IncreaseTimeCommandHandler>();


            services.AddSingleton<IObservableCommandPublisher, CommandPublisher>();
            services.AddSingleton<ICommandHandlerFactory, CommandHandlerFactory>();
        }
    }
}
