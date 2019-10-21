using ECSish;

namespace InverseRPG
{
    public class TrackSliderValue : MonoBehaviourSystem
    {
        private void Update()
        {
            foreach (var entity in GetEntities<TrackSlider, UIText>())
            {
                var slider = GetEntity<TimedSlider, UISlider>().Item2.slider;
                var ui = entity.Item2.text;
                ui.text = slider.value.ToString("0.000");
            }
        }
    }
}