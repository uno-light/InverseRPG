using ECSish;
using TMPro;

namespace InverseRPG
{
    public class UIText : MonoBehaviourComponentData
    {
        public TextMeshProUGUI text;

        private void OnValidate()
        {
            if (!text) text = GetComponentInChildren<TextMeshProUGUI>();
        }
    }
}