namespace ECSish
{
    public class ClearEventSystem : MonoBehaviourSystem
    {
        private void Update()
        {
            EventSystem.ClearEvents();

            foreach (var entity in GetEntities<EntityDestroyed>())
                Destroy(entity.Item1.gameObject);
        }
    }
}
