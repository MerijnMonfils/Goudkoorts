using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model.Score
{
    public class Score
    {
        private int _score;

        public Score()
        {
            _score = 0;
        }

        public int GetScore()
        {
            return _score;
        }

        public void SetScore(int amount)
        {
            _score = _score + amount;
        }
    }
}
