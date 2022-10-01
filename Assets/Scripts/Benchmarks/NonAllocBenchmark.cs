using UnityEngine;

namespace Benchmarks
{
    public class NonAllocBenchmark : BenchmarkBase
    {
        private const float Radius = 10f;

        private readonly Collider[] _colliders = new Collider[100];

        protected override void Init()
        {
            MaxRecommendedIterations = 200000;
            BenchmarkName = "NonAlloc";

            benchmarks.Add(new BenchmarkData("OverlapSphere", () =>
            {
                var result = Physics.OverlapSphere(transform.position, Radius);
            }));

            benchmarks.Add(new BenchmarkData("OverlapSphereNonAlloc", () =>
            {
                var result = Physics.OverlapSphereNonAlloc(transform.position, Radius, _colliders);
            }));
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, Radius);
        }
    }
}