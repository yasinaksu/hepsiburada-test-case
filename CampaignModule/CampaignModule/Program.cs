using Business.Abstract.CommandPublisher;
using Business.Abstract.CommandReader;
using Business.Abstract.Factory;
using Business.Concrete.CommandHandlers;
using Business.Concrete.CommandPublishers;
using Business.Concrete.CommandReaders;
using Business.Concrete.Factory;
using Entities.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CampaignModule
{
    class Program
    {
        static void Main(string[] args)
        {            
            IServiceProvider serviceProvider = BuildServiceProvider();

            IObservableCommandPublisher commandPublisher = serviceProvider.GetService<IObservableCommandPublisher>();
            ICommandHandlerFactory commandHandlerFactory = serviceProvider.GetService<ICommandHandlerFactory>();
            commandPublisher.AddSubscriber(commandHandlerFactory.CreateCreateCampaignCommandHandler());
            commandPublisher.AddSubscriber(commandHandlerFactory.CreateCreateOrderCommandHandler());
            commandPublisher.AddSubscriber(commandHandlerFactory.CreateCreateProductCommandHandler());
            commandPublisher.AddSubscriber(commandHandlerFactory.CreateGetCampaignInfoCommandHandler());
            commandPublisher.AddSubscriber(commandHandlerFactory.CreateGetProductInfoCommandHandler());
            commandPublisher.AddSubscriber(commandHandlerFactory.CreateIncreaseTimeCommandHandler());

            var directoryInfo = CreateDirectoryInfoFromScenariosFolder();
            ICommandReader commandReader = new FileCommandReader();
            foreach (var fileInfo in directoryInfo.GetFiles())
            {
                commandReader.FileInfo = fileInfo;
                var commandList = commandReader.Read();
                foreach (var command in commandList)
                {
                    commandPublisher.PublishCommand(command);
                }
                Console.WriteLine("*******************************************************************************");
            }

        }

        static IServiceProvider BuildServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        static DirectoryInfo CreateDirectoryInfoFromScenariosFolder()
        {
            var executionDirectory = Directory.GetCurrentDirectory();
            var projectRootDirectoryPath = Directory.GetParent(executionDirectory).Parent.Parent.FullName;
            var scenariosDirectoryPath = Path.Combine(projectRootDirectoryPath, "Scenarios");
            var directoryInfo = new DirectoryInfo(scenariosDirectoryPath);
            return directoryInfo;
        }
    }
}
