using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem
{
    public class Spawner : MonoBehaviour
    {
         private UIRoot uIRoot;
        private bool active;
        public UIRoot UIRoot => uIRoot ?? (uIRoot = UIRoot.Instance);

        private void Update()
        {
            if (active)
            {
                OnSpawnCube();
                OnSpawnSphere();
                OnSpawnAutoReturned();
            }
        }

        public void OnActiveSpawn()
        {
            active = !active;
        }

        public void OnSpawnCube()
        {
            UIRoot.ObjectPooler.SpawnFromPool(PoolObjectsTag.Cube);
            UIRoot.Counter.CubesCounter++;
        }

        public void OnSpawnSphere()
        {
            UIRoot.ObjectPooler.SpawnFromPool(PoolObjectsTag.Sphere);
            UIRoot.Counter.SpheresCounter++;
        }

        public void OnSpawnAutoReturned()
        {
            UIRoot.ObjectPooler.SpawnFromPool(PoolObjectsTag.AutoReturned);
            UIRoot.Counter.AutoReturnedCounter++;
        }

        public void OnReset()
        {
            foreach (var poledObject in transform.GetComponentsInChildren<IPooledObject>())
            {
                poledObject.OnObjectReset();
            }

            UIRoot.Counter.Reset();

        }
    }
}
