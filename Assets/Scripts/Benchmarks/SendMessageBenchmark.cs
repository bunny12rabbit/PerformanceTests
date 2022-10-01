using Benchmarks.Benchmark_Helpers;

namespace Benchmarks
{
    public class SendMessageBenchmark : BenchmarkBase
    {
        protected override void Init()
        {
            BenchmarkName = "Send Message";

            benchmarks.Add(new BenchmarkData("Send Message", () => SendMessage(nameof(SendMessageHelper.CallThisMethod), 69)));
            benchmarks.Add(new BenchmarkData("GetComponent", () =>
            {
                var caller = GetComponent<SendMessageHelper>();
                caller.CallThisMethod(69);
            }));
        }
    }
}