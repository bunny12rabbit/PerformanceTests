using Benchmarks.Benchmark_Helpers;
using UnityEngine;

namespace Benchmarks
{
    public class FindBenchmark : BenchmarkBase
    {
        private const int TreeCount = 50;
        private const int LayerCount = 50;
        private const int ObjectsPerLayer = 5;

        protected override void Init()
        {
            MaxRecommendedIterations = 1000;
            BenchmarkName = "Find Objects";

            var last = transform;

            for (var i = 0; i < TreeCount; i++)
            {
                var treeObject = new GameObject($"Tree {i}");
                treeObject.transform.SetParent(last);

                for (var j = 0; j < LayerCount; j++)
                {
                    var layerObject = new GameObject($"Layer {j}");
                    layerObject.transform.SetParent(treeObject.transform);

                    for (var k = 0; k < ObjectsPerLayer; k++)
                    {
                        var obj = new GameObject($"Object {k}") {tag = "Find"};
                        obj.AddComponent<FindHelper>();
                        obj.transform.SetParent(layerObject.transform);
                    }
                }
            }

            benchmarks.Add(new BenchmarkData("FindGameObjectsWithTag", () =>
            {
                var values = GameObject.FindGameObjectsWithTag("Find");
            }));

            benchmarks.Add(new BenchmarkData("FindObjectOfType", () =>
            {
                var values = FindObjectsOfType<FindHelper>();
            }));
        }
    }
}