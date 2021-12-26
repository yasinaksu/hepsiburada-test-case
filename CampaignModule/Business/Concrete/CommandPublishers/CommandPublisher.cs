using Business.Abstract.CommandHandler;
using Business.Abstract.CommandPublisher;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.CommandPublishers
{
    public class CommandPublisher : IObservableCommandPublisher
    {
        private readonly List<IObserverCommandHandler> _commandHandlers;
        public CommandPublisher()
        {
            _commandHandlers = new List<IObserverCommandHandler>();
        }

        public void AddSubscriber(IObserverCommandHandler commandHandler)
        {
            _commandHandlers.Add(commandHandler);
        }

        public void PublishCommand(string command)
        {
            foreach (var commandHandler in _commandHandlers)
            {
                commandHandler.Execute(command);
            }
        }

        public void RemoveSubscriber(IObserverCommandHandler commandHandler)
        {
            _commandHandlers.Remove(commandHandler);
        }
    }
}
