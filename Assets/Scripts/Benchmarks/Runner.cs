using System.Text;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Benchmarks
{
    public class Runner : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _resultLabel;

        [SerializeField]
        private Slider _iterationSlider;

        [SerializeField]
        private TMP_Text _iterationLabel;

        [SerializeField]
        private Transform _buttonParent;

        [SerializeField]
        private BenchmarkButton _buttonPrefab;

        private BenchmarkBase _confirmBenchmark;

        private int Iterations => (int) _iterationSlider.value;

        private void Start()
        {
            _iterationSlider.onValueChanged.AddListener(x => _iterationLabel.text = x.ToString("N0"));
            _iterationSlider.value = 500000;

            foreach (var benchmark in GetComponentsInChildren<BenchmarkBase>())
            {
                var button = Instantiate(_buttonPrefab, _buttonParent);
                button.Init(benchmark.BenchmarkName);

                button.Button.onClick.AddListener(() =>
                {
                    if (Iterations > benchmark.MaxRecommendedIterations && _confirmBenchmark != benchmark)
                    {
                        _confirmBenchmark = benchmark;
                        _iterationSlider.value = benchmark.MaxRecommendedIterations;

                        _resultLabel.text =
                            $"<color=red>Max recommended iterations for this benchmark is {benchmark.MaxRecommendedIterations}.</color>" +
                            " Click the button again to confirm any count (This may crash your computer).)";
                    }
                    else
                    {
                        _confirmBenchmark = null;
                        RunBenchmarks(benchmark);
                    }
                });
            }
        }

        private void RunBenchmarks(BenchmarkBase benchmark)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"<color=orange>{benchmark.BenchmarkName} x {Iterations}</color>");

            foreach (var result in benchmark.RunBenchmark(Iterations))
                builder.AppendLine($"{result.Name}: {result.Result}ms");

            _resultLabel.text = builder.ToString();
        }
    }
}