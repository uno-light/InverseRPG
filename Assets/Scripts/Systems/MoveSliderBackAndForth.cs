using ECSish;
using UnityEngine;

namespace InverseRPG
{
    public class MoveSliderBackAndForth : MonoBehaviourSystem
    {
        private void Update()
        {
            foreach (var entity in GetEntities<TimedSlider, UISlider>())
            {
                var timedSlider = entity.Item1;
                var ui = entity.Item2;

                if (timedSlider.timeFromOneSideToTheOther == 0) continue;

                timedSlider.time += Time.deltaTime/ timedSlider.timeFromOneSideToTheOther;
                ui.slider.value = timedSlider.animationCurve.Evaluate(timedSlider.time);
            }
        }
    }
}