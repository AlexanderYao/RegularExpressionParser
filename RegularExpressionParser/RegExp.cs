using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularExpressionParser
{
    public class RegExp
    {
        private StateMachine _machine;
        public RegExp(string regularExpression)
        {
            _machine = RegExpParser.Parse(regularExpression);
        }

        public bool IsMatch(string input)
        {
            return _machine.IsMatch(input);
        }
    }
}
