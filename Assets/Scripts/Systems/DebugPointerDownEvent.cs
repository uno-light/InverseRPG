using ECSish;
using UnityEngine;

namespace InverseRPG
{
    public class DebugPointerDownEvent : MonoBehaviourSystem
    {
        private void Update()
        {
            foreach (var entity in GetEntities<OnPointerDownEvent>())
            {
                var pointerDownEvent = entity.Item1;
                Debug.Log($"Pointer Down Event Entity: {pointerDownEvent.name}");
            }
        }
    }
}