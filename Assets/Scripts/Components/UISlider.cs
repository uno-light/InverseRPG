using ECSish;
using UnityEngine.UI;

namespace InverseRPG
{
    public class UISlider : MonoBehaviourComponentData
    {
        public Slider slider;

        private void OnValidate()
        {
            if (!slider) slider = GetComponent<Slider>();
        }
    }
}