using UnityEngine;
using UnityEngine.EventSystems;

namespace InverseRPG
{
    public class PointerDownListener : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            ECSish.EventSystem.Add(() =>
            {
                return gameObject.AddComponent<OnPointerDownEvent>();
            });
        }
    }
}