using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ArithmeticSolverV2.Common;

public static class TextReaderExtensions
{
    public static IEnumerable<string> IncomingLines(this TextReader reader) =>
        reader.NullableIncomingLines().TakeWhile(line => !ReferenceEquals(line, null));

    private static IEnumerable<string> NullableIncomingLines(this TextReader reader)
    {
        while (true)
        {
            yield return reader.ReadLine();
        }
    }
}