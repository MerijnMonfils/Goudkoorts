using Goudkoorts.Model.Rails;

namespace Goudkoorts.Model.LinkBuilder
{
    class LinkBuilder
    {
        private char[,] _level;

        public LinkBuilder(char[,] level)
        {
            this._level = level;
            CreateLinks();
        }

        public void CreateLinks()
        {
            
        }

    }
}
