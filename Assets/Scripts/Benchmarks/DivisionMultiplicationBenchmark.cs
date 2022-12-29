using UnityEngine;

namespace Benchmarks
{
    public class DivisionMultiplicationBenchmark : BenchmarkBase
    {
        protected override void Init()
        {
            BenchmarkName = "Division vs Multiplication";

            benchmarks.Add(new BenchmarkData("Vector divide by 2", () =>
            {
                var a = Vector2.one / 2;
            }));

            benchmarks.Add(new BenchmarkData("Vector multiply by 0.5f", () =>
            {
                var a = Vector2.one * 0.5f;
            }));

            benchmarks.Add(new BenchmarkData("number divide by 2", () =>
            {
                var a = 120 / 2;
            }));

            benchmarks.Add(new BenchmarkData("number multiply by 0.5f (float result)", () =>
            {
                var a = 120 * 0.5f;
            }));

            benchmarks.Add(new BenchmarkData("number multiply by 0.5f (cast to int)", () =>
            {
                var a = (int) (120 * 0.5f);
            }));
        }
    }
}