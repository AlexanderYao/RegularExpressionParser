using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularExpressionParser
{
    public interface IParser
    {
        char KeyWord { get; }

        MatchStatus IsMatch(string input, int index);

        IParser Clone(char keyWord);
    }
}
