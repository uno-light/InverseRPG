using ECSish;

namespace InverseRPG
{
    public class ToggleOnPointerDown : MonoBehaviourSystem
    {
        private void Update()
        {
            foreach (var entity in GetEntities<OnPointerDownEvent, ToggleListener>())
            {
                var pointerDownEvent = entity.Item1;
                var toggleListener = entity.Item2;
                var toggle = toggleListener.GetComponent<ToggleGameObjectActiveEvent>();

                foreach (var hideOnToggle in GetEntities<HideOnToggle>())
                    if (hideOnToggle.Item1.gameObject != toggle.toggleGameObject)
                        hideOnToggle.Item1.gameObject.SetActive(false);

                toggle.toggleGameObject.SetActive(!toggle.toggleGameObject.activeSelf);
            }
        }
    }
}