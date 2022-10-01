using UnityEngine;

namespace Benchmarks
{
    public class OrderOfOperationsBenchmark : BenchmarkBase
    {
        private readonly Vector3 _vector3 = new(789, 123, 456);

        private const float Multiplier = 4675.98f;

        protected override void Init()
        {
            BenchmarkName = "Order Of Operations";

            benchmarks.Add(new BenchmarkData("Float * Float * Vector", () =>
            {
                var result = Multiplier * Multiplier * _vector3;
            }));

            benchmarks.Add(new BenchmarkData("Float * Vector * Float", () =>
            {
                var result = Multiplier * _vector3 * Multiplier;
            }));

            benchmarks.Add(new BenchmarkData("Vector * Float * Float", () =>
            {
                var result = _vector3 * Multiplier * Multiplier;
            }));
        }
    }
}