using ECSish;

namespace InverseRPG
{
    public class ToggleGameObjectActive : MonoBehaviourSystem
    {
        private void Update()
        {
            foreach(var entity in GetEntities<ToggleGameObjectActiveEvent>())
            {
                var toggleGameObject = entity.Item1.toggleGameObject;
                toggleGameObject.SetActive(!toggleGameObject.activeSelf);
            }
        }
    }
}