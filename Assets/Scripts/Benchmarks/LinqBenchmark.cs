using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Benchmarks
{
    public class LinqBenchmark : BenchmarkBase
    {
        private struct LinqData
        {
            public int Value;
            public float ValueTwo;
        }

        private const int Count = 10000;
        private const int Threshold = 5000;

        private readonly List<LinqData> _data = new();

        protected override void Init()
        {
            MaxRecommendedIterations = 1000;
            BenchmarkName = "Linq vs Loop";

            for (var i = 0; i < Count; i++)
            {
                _data.Add(new LinqData
                {
                    Value = Random.Range(0, 1000000),
                    ValueTwo = Random.Range(0, 1000000f)
                });
            }

            benchmarks.Add(new BenchmarkData("Linq", () =>
            {
                var values = _data.Where(x => x.Value > Threshold).Select(y => y.ValueTwo).ToList();
            }));

            benchmarks.Add(new BenchmarkData("For", () =>
            {
                var values = new List<float>();

                for (var i = 0; i < _data.Count; i++)
                {
                    if (_data[i].Value > Threshold)
                        values.Add(_data[i].ValueTwo);
                }
            }));

            benchmarks.Add(new BenchmarkData("Cached for", () =>
            {
                var values = new List<float>();
                var count = _data.Count;

                for (var i = 0; i < count; i++)
                {
                    if (_data[i].Value > Threshold)
                        values.Add(_data[i].ValueTwo);
                }
            }));

            benchmarks.Add(new BenchmarkData("Foreach", () =>
            {
                var values = new List<float>();

                foreach (var data in _data)
                {
                    if (data.Value > Threshold)
                        values.Add(data.ValueTwo);
                }
            }));
        }
    }
}