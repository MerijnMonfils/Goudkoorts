using System;
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

        public char[,] LoadLevel()
        {
            string[] lines = System.IO.File.ReadAllLines(_file);

            char[,] _level = new char[lines.Length, lines[0].Length];
            
            for (int z = 0; z < lines.Length; z++) // for each row
                for (int i = 0; i < (lines[z].Length); i++) // for length of row
                    _level[z, i] = lines[z][i];
            return _level;
        }
    }
}
