using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularExpressionParser
{
    /// <summary>
    /// 匹配1、多个字符
    /// </summary>
    public class PositiveParser : IParser
    {
        private int _validCount;

        public PositiveParser(char keyWork)
        {
            this.KeyWord = keyWork;
            this._validCount = 0;
        }

        public char KeyWord
        {
            get;
            private set;
        }

        public static PositiveParser Empty
        {
            get
            {
                return new PositiveParser(char.MinValue);
            }
        }

        public MatchStatus IsMatch(string input, int index)
        {
            if (index < 0 || index > input.Length)
            {
                throw new IndexOutOfRangeException();
            }

            char c = (index == input.Length) ? char.MinValue : input[index];

            if (c == KeyWord)
            {
                _validCount++;
                return MatchStatus.Match;
            }
            else
            {
                return _validCount > 0 ? MatchStatus.Exited : MatchStatus.NotMatch;
            }
        }

        public IParser Clone(char keyWord)
        {
            return new PositiveParser(keyWord);
        }
    }
}
