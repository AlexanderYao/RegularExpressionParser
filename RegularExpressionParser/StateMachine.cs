using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularExpressionParser
{
    class StateMachine
    {
        private List<IParser> _parsers;
        internal StateMachine()
        {
            _parsers = new List<IParser>();
        }

        internal void AddParser(IParser parser)
        {
            if (null == parser)
            {
                throw new ArgumentNullException();
            }

            _parsers.Add(parser);
        }

        internal bool IsMatch(string input)
        {
            int charIndex = 0;
            int parserIndex = 0;

            //先遍历字符串
            for (; charIndex < input.Length; charIndex++)
            {
                char c = input[charIndex];

                while (true)
                {
                    if (parserIndex >= _parsers.Count)
                    {
                        return false;
                    }

                    MatchStatus status = _parsers[parserIndex].IsMatch(input, charIndex);
                    
                    if(status == MatchStatus.NotMatch)
                    {
                        return false;
                    }
                    else if (status == MatchStatus.Match)
                    {
                        break;
                    }
                    else if(status == MatchStatus.Exited)
                    {
                        parserIndex++;
                    }
                }
            }

            //再遍历剩下的parser
            while (parserIndex < _parsers.Count)
            {
                MatchStatus status = _parsers[parserIndex].IsMatch(input, charIndex);

                if(status == MatchStatus.NotMatch)
                {
                    return false;
                }

                parserIndex++;
            }

            return true;
        }
    }
}
