using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private UIRoot uIRoot;
        private bool active;

        private void Update()
        {
            if (active)
            {
                SpawnCube();
                SpawnSphere();
                SpawnAutoReturned();
            }
        }

        public void ActiveSpawn()
        {
            active = !active;
        }

        public void SpawnCube()
        {
            uIRoot.ObjectPooler.SpawnFromPool(PoolObjectsTag.Cube);
            uIRoot.Counter.CubesCounter++;
        }

        public void SpawnSphere()
        {
            uIRoot.ObjectPooler.SpawnFromPool(PoolObjectsTag.Sphere);
            uIRoot.Counter.SpheresCounter++;
        }

        public void SpawnAutoReturned()
        {
            uIRoot.ObjectPooler.SpawnFromPool(PoolObjectsTag.AutoReturned);
            uIRoot.Counter.AutoReturnedCounter++;
        }

        public void Reset()
        {
            uIRoot.ObjectPooler.Reset();
            uIRoot.Counter.Reset();

        }
    }
}
