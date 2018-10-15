using System.IO;

namespace Goudkoorts.Model.FileReading
{
    class FileReader
    {
        // file reading resources
        private string _path;
        private string _file;
        private DirectoryInfo _di;

        public FileReader()
        {
            this._path = ("..\\Level");
            this._di = new DirectoryInfo(_path);
            _file = _di.GetFiles()[0].FullName;
        }


    }
}
