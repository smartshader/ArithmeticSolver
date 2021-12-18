using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ArithmeticSolverV2;

public static class TextReaderExtensions
{
    public static IEnumerable<string> IncomingLines(this TextReader reader) =>
        Enumerable.Empty<string>();
}