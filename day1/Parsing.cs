using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common;

public static class Parsing
{
    public static IEnumerable<string?> ParseSingleLine(string fileName)
    {
        using var stream = File.OpenText(fileName);
        while (!stream.EndOfStream)
        {
            yield return stream.ReadLine();
        }
    }

    public static IEnumerable<IEnumerable<string>> SplitBy(this IEnumerable<string?> seq, Func<string?, bool> endChunk)
    {
        List<string> result = new();
        foreach (var str in seq)
        {
            if (endChunk(str))
            {
                yield return result;
                result = new();
            }
            else
            {
                result.Add(str);
            }
        }
        if (result.Count > 0) yield return result;
    }
}
