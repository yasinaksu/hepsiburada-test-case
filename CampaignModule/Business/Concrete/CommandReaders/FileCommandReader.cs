using Business.Abstract.CommandReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.CommandReaders
{
    public class FileCommandReader : ICommandReader
    {
        private FileInfo _fileInfo;
        public FileCommandReader(string filePath)
        {
            _fileInfo = new FileInfo(filePath);
        }

        public FileCommandReader(FileInfo fileInfo)
        {
            _fileInfo = fileInfo;
        }
        public FileCommandReader()
        {

        }

        public FileInfo FileInfo
        {
            set
            {
                _fileInfo = value;
            }
        }
        public List<string> Read()
        {
            var commandList = new List<string>();
            using (var streamReader = _fileInfo.OpenText())
            {
                string command;
                while ((command = streamReader.ReadLine()) != null)
                {
                    commandList.Add(command);
                }
            }
            return commandList;
        }
    }
}
