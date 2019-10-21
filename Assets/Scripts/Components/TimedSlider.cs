using ECSish;
using UnityEngine;

namespace InverseRPG
{
    public class TimedSlider : MonoBehaviourComponentData
    {
        public AnimationCurve animationCurve;
        public float timeFromOneSideToTheOther;
        public float time;
    }
}