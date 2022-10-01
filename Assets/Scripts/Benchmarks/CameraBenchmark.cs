using UnityEngine;

namespace Benchmarks
{
    public class CameraBenchmark : BenchmarkBase
    {
        private Camera _camera;

        protected override void Init()
        {
            BenchmarkName = "Camera Access";

            _camera = Camera.main;

            benchmarks.Add(new BenchmarkData("Camera.main", () =>
            {
                var cam = Camera.main;
                var aspect = cam.aspect;
            }));

            benchmarks.Add(new BenchmarkData("FindWithTag", () =>
            {
                var cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
                var aspect = cam.aspect;
            }));

            benchmarks.Add(new BenchmarkData("FindObjectOfType", () =>
            {
                var cam = FindObjectOfType<Camera>();
                var aspect = cam.aspect;
            }));

            benchmarks.Add(new BenchmarkData("Cached Camera", () =>
            {
                var aspect = _camera.aspect;
            }));
        }
    }
}