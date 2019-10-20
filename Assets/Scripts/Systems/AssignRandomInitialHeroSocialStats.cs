using ECSish;
using UnityEngine;

namespace InverseRPG
{
    public class AssignRandomInitialHeroSocialStats : MonoBehaviourSystem
    {
        private void Update()
        {
            foreach(var entity in GetEntities<RandomInitialHeroSocialStats>())
            {
                var randomStats = entity.Item1;

                randomStats.surprise = Random.Range(randomStats.minValue, randomStats.maxValue);
                randomStats.fear = Random.Range(randomStats.minValue, randomStats.maxValue);
                randomStats.amusement = Random.Range(randomStats.minValue, randomStats.maxValue);
                randomStats.conquest = Random.Range(randomStats.minValue, randomStats.maxValue);
                randomStats.pride = Random.Range(randomStats.minValue, randomStats.maxValue);
                randomStats.safety = Random.Range(randomStats.minValue, randomStats.maxValue);
                randomStats.smart = Random.Range(randomStats.minValue, randomStats.maxValue);

                var heroStats = GetEntity<HeroSocialStats>().Item1;
                heroStats.surprise = randomStats.surprise;
                heroStats.fear = randomStats.fear;
                heroStats.amusement = randomStats.amusement;
                heroStats.conquest = randomStats.conquest;
                heroStats.pride = randomStats.pride;
                heroStats.safety = randomStats.safety;
                heroStats.smart = randomStats.smart;

                randomStats.enabled = false;
            }
        }
    }
}