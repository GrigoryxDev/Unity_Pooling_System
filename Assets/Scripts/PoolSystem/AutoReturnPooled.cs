using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem
{
    public class AutoReturnPooled : MonoBehaviour
    {
        [SerializeField] private float time = 5.0f;
        [SerializeField] private Material material;
        private float currentTime;
        private void OnEnable()
        {
            currentTime = time;
            StartCoroutine(StartCountdown());
        }
        private IEnumerator StartCountdown()
        {
            while (currentTime > 0)
            {
                yield return new WaitForSeconds(1f);
                var color = material.color;
                color.r = Random.Range(0f, 1f);
                color.g = Random.Range(0f, 1f);
                color.b = Random.Range(0f, 1f);
                material.color = color;
                currentTime--;
            }
            GetComponent<IPooledObject>().OnObjectDestroy();
        }

    }
}