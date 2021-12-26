using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.CommandReader
{
    public interface ICommandReader
    {
        List<string> Read();
        FileInfo FileInfo { set; }
    }
}
