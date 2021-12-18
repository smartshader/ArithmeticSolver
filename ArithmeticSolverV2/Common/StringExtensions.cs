using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ArithmeticSolverV2.Common;

public static class StringExtensions
{
    public static IEnumerable<int> ToNonNegativeInts(this string line) =>
        Regex.Matches(line, @"\d+")
            .AsEnumerable()
            .Select(match => match.Value)
            .Select(int.Parse);
}