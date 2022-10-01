using System.Text;

namespace Benchmarks
{
    public class StringBenchmark : BenchmarkBase
    {
        private const int Count = 100;

        private const string Phrase = "Hello, bench! :)";

        protected override void Init()
        {
            BenchmarkName = "String Builder";
            MaxRecommendedIterations = 10000;

            benchmarks.Add(new BenchmarkData("Concatenation", () =>
            {
                var value = "";

                for (var i = 0; i < Count; i++)
                    value += Phrase;
            }));

            benchmarks.Add(new BenchmarkData("Builder", () =>
            {
                var builder = new StringBuilder();

                for (var i = 0; i < Count; i++)
                    builder.Append(Phrase);

                var value = builder.ToString();
            }));
        }
    }
}