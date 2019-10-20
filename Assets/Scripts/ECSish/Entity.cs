using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ECSish
{

    public static class Entity
    {
        public static bool isInitialized;
        public static Dictionary<Type, List<GameObject>> gameObjects = new Dictionary<Type, List<GameObject>>();
        public static Queue<MonoBehaviourComponentData> toBeAddedComponent = new Queue<MonoBehaviourComponentData>();
        public static Queue<MonoBehaviourComponentData> toBeRemovedCompenent = new Queue<MonoBehaviourComponentData>();
        public static Queue<GameObject> toBeAddedGameObject = new Queue<GameObject>();
        public static Queue<GameObject> toBeRemovedGameObject = new Queue<GameObject>();

        public static IEnumerable<GameObject> GetGameObjects<T>() where T : MonoBehaviourComponentData
        {
            return gameObjects[typeof(T)];
        }

        public static void Initialize()
        {
            if (isInitialized) return;

            isInitialized = true;
            var types = typeof(MonoBehaviourComponentData).Assembly.GetTypes();
            foreach (var type in types)
                if (type.IsSubclassOf(typeof(MonoBehaviourComponentData)))
                    gameObjects.Add(type, new List<GameObject>());
        }

        public static void Add(MonoBehaviourComponentData component)
        {
            toBeAddedComponent.Enqueue(component);
            toBeAddedGameObject.Enqueue(component.gameObject);
        }

        public static void Remove(MonoBehaviourComponentData component)
        {
            toBeRemovedCompenent.Enqueue(component);
            toBeRemovedGameObject.Enqueue(component.gameObject);
        }

        public static void UpdateDatabase()
        {
            while (toBeAddedComponent.Count > 0)
                gameObjects[toBeAddedComponent.Dequeue().GetType()].Add(toBeAddedGameObject.Dequeue());

            while (toBeRemovedCompenent.Count > 0)
                gameObjects[toBeRemovedCompenent.Dequeue().GetType()].Remove(toBeRemovedGameObject.Dequeue());
        }

        public static GameObject Instantiate(GameObject prefab)
        {
            return Object.Instantiate(prefab);
        }

        public static void Destroy(GameObject gameObject)
        {
            gameObject.AddComponent<EntityDestroyed>();
        }
    }
}