using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BenchmarkButton : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _label;

        [SerializeField]
        private Button _button;
        public Button Button => _button;

        public void Init(string label) => _label.text = label;
    }
}