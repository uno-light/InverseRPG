using ECSish;
using UnityEngine;
using UnityEngine.UI;

namespace InverseRPG
{
    public class UpdateHeroSocialStats : MonoBehaviourSystem
    {
        private void Update()
        {
            foreach (var entity in GetEntities<HeroSocialStatsUI, UIGraph>())
            {
                var graph = entity.Item2;
                if (graph.maxHeight == 0 && graph.bar1.sizeDelta.y > 0)
                {
                    graph.maxHeight = graph.bar1.sizeDelta.y;
                    var horizontalLayout = graph.bar1.GetComponentInParent<HorizontalLayoutGroup>();
                    horizontalLayout.childControlHeight = false;
                }

                var socialStats = GetEntity<HeroSocialStats>().Item1;
                if (socialStats && graph.maxHeight > 0)
                {

                    SetBarSize(graph.bar1, socialStats.surprise, graph.maxValue, graph.maxHeight);
                    SetBarSize(graph.bar2, socialStats.fear, graph.maxValue, graph.maxHeight);
                    SetBarSize(graph.bar3, socialStats.amusement, graph.maxValue, graph.maxHeight);
                    SetBarSize(graph.bar4, socialStats.conquest, graph.maxValue, graph.maxHeight);
                    SetBarSize(graph.bar5, socialStats.pride, graph.maxValue, graph.maxHeight);
                    SetBarSize(graph.bar6, socialStats.safety, graph.maxValue, graph.maxHeight);
                    SetBarSize(graph.bar7, socialStats.smart, graph.maxValue, graph.maxHeight);
                }
            }
        }

        private void SetBarSize(RectTransform bar, float value, float maxValue, float maxHeight)
        {
            var barSize = bar.sizeDelta;
            barSize.y = value / maxValue * maxHeight;
            bar.sizeDelta = barSize;
        }
    }
}