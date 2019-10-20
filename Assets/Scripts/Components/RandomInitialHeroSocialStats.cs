using ECSish;
using UnityEngine;

namespace InverseRPG
{
    public class RandomInitialHeroSocialStats : MonoBehaviourComponentData
    {
        public float minValue;
        public float maxValue;

        [Header("Assigned Values")]
        public float surprise;
        public float fear;
        public float amusement;
        public float conquest;
        public float pride;
        public float safety;
        public float smart;
    }
}