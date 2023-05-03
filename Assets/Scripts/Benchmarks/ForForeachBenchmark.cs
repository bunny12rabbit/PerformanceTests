using System.Collections.Generic;
using UnityEngine;

namespace Benchmarks
{
    public class ForForeachBenchmark : BenchmarkBase
    {
        private const int Count = 10000;
        private const int Threshold = 5000;

        private readonly List<int> _list = new(Count);
        private readonly int[] _array = new int[Count];

        private int _tmp;

        protected override void Init()
        {
            MaxRecommendedIterations = 10000;
            BenchmarkName = "For vs Foreach Loops";

            for (var i = 0; i < Count; i++)
            {
                _list.Add(Random.Range(0, 1000000));
                _array[i] = Random.Range(0, 1000000);
            }

            benchmarks.Add(new BenchmarkData("foreach array", () =>
            {
                foreach (var element in _array)
                {
                    if (element > Threshold)
                        _tmp = element;
                }
            }));

            benchmarks.Add(new BenchmarkData("for array", () =>
            {
                var tmp = 0;

                for (var i = 0; i < _array.Length; i++)
                {
                    var element = _array[i];

                    if (element > Threshold)
                        tmp = element;
                }
            }));

            benchmarks.Add(new BenchmarkData("foreach list", () =>
            {
                var tmp = 0;

                foreach (var element in _list)
                {
                    if (element > Threshold)
                        tmp = element;
                }
            }));

            benchmarks.Add(new BenchmarkData("for list", () =>
            {
                var tmp = 0;

                for (var i = 0; i < _list.Count; i++)
                {
                    var element = _list[i];

                    if (element > Threshold)
                        tmp = element;
                }
            }));
        }
    }
}