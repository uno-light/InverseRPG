using ECSish;

namespace InverseRPG
{
    public class ShowStatsOnMonsterPointerDownEvent : MonoBehaviourSystem
    {
        private void Update()
        {
            foreach (var entity in GetEntities<OnPointerDownEvent, Monster>())
            {
                var pointerDownEvent = entity.Item1;
                var monster = entity.Item2;

                var toggle = monster.GetComponent<ToggleGameObjectActiveEvent>();
                toggle.toggleGameObject.SetActive(!toggle.toggleGameObject.activeSelf);
            }
        }
    }
}