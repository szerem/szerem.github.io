using System.Text;
using BenchmarkDotNet.Attributes;

namespace MyBenchmarks;

public class StringBenchmark
{
    [Params(12, 14, 16, 18, 20, 22, 24)] public int NumberOfRuns;

    [Benchmark]
    public string StringBuilder()
    {
        StringBuilder stringBuilder = new();
        for (int i = 0; i < NumberOfRuns; i++)
        {
            stringBuilder.AppendLine("Hello World");
        }
        return stringBuilder.ToString();
    }
    
    
    [Benchmark]
    public string StringConcatenation()
    {
        String stringBuilder = string.Empty;
        for (int i = 0; i < NumberOfRuns; i++)
        {
            stringBuilder += "Hello World";
        }
        return stringBuilder;
    }
}
