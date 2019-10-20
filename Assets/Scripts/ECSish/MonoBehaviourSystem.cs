using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ECSish
{
    public abstract class MonoBehaviourSystem : MonoBehaviour
    {
        public IEnumerable<Tuple<T1>> GetEntities<T1>()
            where T1 : MonoBehaviourComponentData
        {
            foreach (var gameObject in Entity.GetGameObjects<T1>())
            {
                if (!gameObject) continue;
                var component1 = gameObject.GetComponent<T1>(false);
                yield return new Tuple<T1>(component1);
            }
        }

        public IEnumerable<Tuple<T1, T2>> GetEntities<T1, T2>()
            where T1 : MonoBehaviourComponentData
            where T2 : MonoBehaviourComponentData
        {
            var g1 = Entity.GetGameObjects<T1>();
            var g2 = Entity.GetGameObjects<T2>();
            foreach (var gameObject in g1.Intersect(g2))
            {
                if (!gameObject) continue;
                var component1 = gameObject.GetComponent<T1>(false);
                var component2 = gameObject.GetComponent<T2>(false);
                yield return new Tuple<T1, T2>(component1, component2);
            }
        }

        public IEnumerable<Tuple<T1, T2, T3>> GetEntities<T1, T2, T3>()
            where T1 : MonoBehaviourComponentData
            where T2 : MonoBehaviourComponentData
            where T3 : MonoBehaviourComponentData
        {
            var g1 = Entity.GetGameObjects<T1>();
            var g2 = Entity.GetGameObjects<T2>();
            var g3 = Entity.GetGameObjects<T3>();
            foreach (var gameObject in g1.Intersect(g2).Intersect(g3))
            {
                if (!gameObject) continue;
                var component1 = gameObject.GetComponent<T1>(false);
                var component2 = gameObject.GetComponent<T2>(false);
                var component3 = gameObject.GetComponent<T3>(false);
                yield return new Tuple<T1, T2, T3>(component1, component2, component3);
            }
        }

        public IEnumerable<Tuple<T1, T2, T3, T4>> GetEntities<T1, T2, T3, T4>()
            where T1 : MonoBehaviourComponentData
            where T2 : MonoBehaviourComponentData
            where T3 : MonoBehaviourComponentData
            where T4 : MonoBehaviourComponentData
        {
            var g1 = Entity.GetGameObjects<T1>();
            var g2 = Entity.GetGameObjects<T2>();
            var g3 = Entity.GetGameObjects<T3>();
            var g4 = Entity.GetGameObjects<T4>();
            foreach (var gameObject in g1.Intersect(g2).Intersect(g3).Intersect(g4))
            {
                if (!gameObject) continue;
                var component1 = gameObject.GetComponent<T1>(false);
                var component2 = gameObject.GetComponent<T2>(false);
                var component3 = gameObject.GetComponent<T3>(false);
                var component4 = gameObject.GetComponent<T4>(false);
                yield return new Tuple<T1, T2, T3, T4>(component1, component2, component3, component4);
            }
        }

        public Tuple<T1> GetEntity<T1>() where T1 : MonoBehaviourComponentData
            => GetEntities<T1>().FirstOrDefault();

        public Tuple<T1, T2> GetEntity<T1, T2>()
            where T1 : MonoBehaviourComponentData
            where T2 : MonoBehaviourComponentData
            => GetEntities<T1, T2>().FirstOrDefault();

        public Tuple<T1, T2, T3> GetEntity<T1, T2, T3>()
            where T1 : MonoBehaviourComponentData
            where T2 : MonoBehaviourComponentData
            where T3 : MonoBehaviourComponentData
            => GetEntities<T1, T2, T3>().FirstOrDefault();

        public Tuple<T1, T2, T3, T4> GetEntity<T1, T2, T3, T4>()
            where T1 : MonoBehaviourComponentData
            where T2 : MonoBehaviourComponentData
            where T3 : MonoBehaviourComponentData
            where T4 : MonoBehaviourComponentData
            => GetEntities<T1, T2, T3, T4>().FirstOrDefault();
    }
}