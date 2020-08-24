using System.Collections;
using System.Collections.Generic;
using SpawnSystem;
using UnityEngine;

namespace Objects
{
    /// <summary>
    /// Base class for similar spawn objects
    /// </summary> 
    public abstract class BaseObject : MonoBehaviour, IPooledObject
    {
        [SerializeField] protected float upForce = 1f;
        [SerializeField] protected float sideForce = .1f;
        protected static UIRoot uIRoot;
        public static UIRoot UIRoot => uIRoot ?? (uIRoot = UIRoot.Instance);
        public PoolObjectsTag Tag { get; set; }

        protected virtual void AddForce()
        {
            float xForce = Random.Range(-sideForce, sideForce);
            float yForce = Random.Range(upForce / 2f, upForce);
            float zForce = Random.Range(-sideForce, sideForce);

            Vector3 force = new Vector3(xForce, yForce, zForce);

            GetComponent<Rigidbody>().velocity = force;
        }

        protected virtual void OnMouseDown()
        {
            OnObjectDestroy();
        }

        public virtual void OnObjectSpawn()
        {
            AddForce();
        }

        public virtual void OnObjectReset()
        {
            UIRoot.ObjectPooler.ReturnToThePool(gameObject);
        }

        public virtual void OnObjectDestroy()
        {
            switch (Tag)
            {
                case PoolObjectsTag.Cube:
                    UIRoot.Counter.CubesCounter--;
                    break;
                case PoolObjectsTag.Sphere:
                    UIRoot.Counter.SpheresCounter--;
                    break;
                case PoolObjectsTag.AutoReturned:
                    UIRoot.Counter.AutoReturnedCounter--;
                    break;
            }

            OnObjectReset();
        }
    }
}