using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularExpressionParser
{
    public class StarParser : IParser
    {
        private int _validCount;

        public StarParser(char keyWork)
        {
            this.KeyWord = keyWork;
            this._validCount = 0;
        }

        public char KeyWord
        {
            get;
            private set;
        }

        public static StarParser Empty
        {
            get
            {
                return new StarParser(char.MinValue);
            }
        }

        /// <summary>
        /// *不存在NotMatch状态
        /// </summary>
        /// <param name="input"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public MatchStatus IsMatch(string input, int index)
        {
            if(input[index] == KeyWord)
            {
                return MatchStatus.Match;
            }
            else
            {
                return MatchStatus.Exited;
            }
        }

        public IParser Clone(char keyWord)
        {
            return new StarParser(keyWord);
        }        
    }
}
