using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem
{
    public class ObjectPooler : MonoBehaviour
    {
        [SerializeField] private Pool[] pools;
        private Dictionary<PoolObjectsTag, Queue<GameObject>> poolDictionary;

        private void Start()
        {
            poolDictionary = new Dictionary<PoolObjectsTag, Queue<GameObject>>();

            foreach (Pool pool in pools)
            {
                var objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.maxSize; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.transform.SetParent(transform);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }

                poolDictionary.Add(pool.tag, objectPool);
            }
        }


        public GameObject SpawnFromPool(PoolObjectsTag tag)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning($"Pool with tag {tag}, doesn't excists");
                return null;
            }
            else if (poolDictionary[tag].Count == 0)
            {
                poolDictionary[tag].Enqueue(CreateInstance(tag));
            }

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = transform.position;
            objectToSpawn.transform.rotation = Quaternion.identity;

            var pooledObj = objectToSpawn.GetComponent<IPooledObject>();

            if (pooledObj != null)
            {
                pooledObj.OnObjectSpawn();
                pooledObj.Tag = tag;
            }

            objectToSpawn.transform.SetParent(transform);

            return objectToSpawn;
        }

        public void ReturnToThePool(GameObject obj)
        {
            var pooledObjectTag = obj.GetComponent<IPooledObject>().Tag;
            obj.SetActive(false);
            poolDictionary[pooledObjectTag].Enqueue(obj);
        }

        public void Reset()
        {
            foreach (var poledObject in transform.GetComponentsInChildren<IPooledObject>())
            {
                poledObject.OnObjectReset();
            }
        }

        private GameObject CreateInstance(PoolObjectsTag tag)
        {
            GameObject prefab = null;
            foreach (var item in pools)
            {
                if (item.tag == tag)
                {
                    prefab = item.prefab;
                    break;
                }
            }

            if (prefab == null)
            {
                Debug.LogWarning($"Instantiation tag:{tag} error");
                return null;
            }

            var obj = Instantiate(prefab);

            return obj;
        }
    }
}