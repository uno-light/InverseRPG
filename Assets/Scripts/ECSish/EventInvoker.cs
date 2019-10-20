using ECSish;
using UnityEngine;

namespace Asteroids
{
    public class EventInvoker : MonoBehaviour
    {
        public MonoBehaviourComponentData componentEvent;

        private void OnValidate()
        {
            if (!componentEvent) componentEvent = GetComponent<MonoBehaviourComponentData>();
        }

        public void Invoke()
        {
            var type = componentEvent.GetType();
            var newEventInstance = (MonoBehaviourComponentData)gameObject.AddComponent(type);

            foreach (var field in type.GetFields())
                field.SetValue(newEventInstance, field.GetValue(componentEvent));

            EventSystem.Add(() =>
            {
                newEventInstance.enabled = true;
                return newEventInstance;
            });
        }
    }
}