using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.CommandHandler
{
    public interface IObserverCommandHandler
    {
        void Execute(string command);
    }
}
