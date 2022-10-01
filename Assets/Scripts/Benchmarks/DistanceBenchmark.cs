using UnityEngine;

namespace Benchmarks
{
    public class DistanceBenchmark : BenchmarkBase
    {
        private readonly Vector3 _a = new(4567, 2354.58f, 205);
        private readonly Vector3 _b = new(856.74f, 15.6f, 9123.45f);

        protected override void Init()
        {
            BenchmarkName = "Distance";

            benchmarks.Add(new BenchmarkData("Vector3.Distance", () =>
            {
                var value = Vector3.Distance(_a, _b);
            }));

            benchmarks.Add(new BenchmarkData("Square Magnitude", () =>
            {
                var value = (_a - _b).sqrMagnitude;
            }));
        }
    }
}