using Business.Abstract.CommandHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.CommandPublisher
{
    public interface IObservableCommandPublisher
    {
        void AddSubscriber(IObserverCommandHandler commandHandler);
        void RemoveSubscriber(IObserverCommandHandler commandHandler);
        void PublishCommand(string command);
    }
}
