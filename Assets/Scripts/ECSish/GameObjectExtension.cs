using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ECSish
{
    public static class GameObjectExtension
    {
        public static T GetComponent<T>(this GameObject gameObject, bool includeInactive)
            where T : MonoBehaviour
        {
            return GetComponents<T>(gameObject, includeInactive).FirstOrDefault();
        }

        public static IEnumerable<T> GetComponents<T>(this GameObject gameObject, bool includeInactive)
            where T : MonoBehaviour
        {
            foreach (var component in gameObject.GetComponents<T>())
                if (component.enabled)
                    yield return component;
                else if (includeInactive && !component.enabled)
                    yield return component;
        }
    }
}
