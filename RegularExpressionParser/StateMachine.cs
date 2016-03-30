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
            int parserIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                while (true)
                {
                    if (parserIndex >= _parsers.Count)
                    {
                        return false;
                    }

                    MatchStatus status = _parsers[parserIndex].IsMatch(input, i);
                    
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

            return true;
        }
    }
}
