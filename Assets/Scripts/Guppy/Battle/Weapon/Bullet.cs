using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float destroyTime = 1f;

        private float time = 0f;

        void Update()
        {
            time += Time.deltaTime;
            if(time >= destroyTime)
            {
                Destroy(gameObject);
            }
        }
    }
}
