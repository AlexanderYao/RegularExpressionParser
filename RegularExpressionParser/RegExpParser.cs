using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularExpressionParser
{
    class RegExpParser
    {
        private static Dictionary<char, IParser> _dic;

        static RegExpParser()
        {
            _dic = new Dictionary<char, IParser>();
            _dic.Add('*', StarParser.Empty);
        }

        public static void Register(char c, IParser parser)
        {
            if (null == parser)
            {
                throw new ArgumentNullException();
            }

            _dic.Add(c, parser);
        }

        internal static StateMachine Parse(string regularExpression)
        {
            StateMachine machine = new StateMachine();
            char normal = char.MinValue;

            for (int i = 0; i < regularExpression.Length; i++)
            {
                char c = regularExpression[i];

                if (_dic.ContainsKey(c))
                {
                    machine.AddParser(_dic[c].Clone(normal));
                    normal = char.MinValue;
                }
                else
                {
                    normal = c;
                }
            }

            return machine;
        }
    }
}
