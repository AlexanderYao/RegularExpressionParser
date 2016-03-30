using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularExpressionParser
{
    /// <summary>
    /// 匹配0、1、多个字符
    /// </summary>
    public class StarParser : IParser
    {
        public StarParser(char keyWork)
        {
            this.KeyWord = keyWork;
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
        public MatchStatus IsMatch(string input, int index)
        {
            if (index < 0 || index > input.Length)
            {
                throw new IndexOutOfRangeException();
            }

            char c = (index == input.Length) ? char.MinValue : input[index];

            if (c == KeyWord)
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
