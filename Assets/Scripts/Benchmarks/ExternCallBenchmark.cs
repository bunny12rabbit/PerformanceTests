using UnityEngine;

namespace Benchmarks
{
    public class ExternCallBenchmark : BenchmarkBase
    {
        private Transform _transform;

        protected override void Init()
        {
            BenchmarkName = "Extern Call Caching";

            _transform = transform;

            benchmarks.Add(new BenchmarkData("Not caching", () =>
            {
                var position = transform.position;
                var rotation = transform.rotation;
                var scale = transform.localScale;
            }));

            benchmarks.Add(new BenchmarkData("Cached per test", () =>
            {
                var t = transform;
                var position = t.position;
                var rotation = t.rotation;
                var scale = t.localScale;
            }));

            benchmarks.Add(new BenchmarkData("Fully cached", () =>
            {
                var position = _transform.position;
                var rotation = _transform.rotation;
                var scale = _transform.localScale;
            }));
        }
    }
}