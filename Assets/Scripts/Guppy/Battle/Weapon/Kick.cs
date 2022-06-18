using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Kick : MonoBehaviour
    {
        [SerializeField] private float destroyTime = 0.5f;

        private float time = 0f;

        void Update()
        {
            time += Time.deltaTime;

            if (time >= destroyTime)
            {
                Destroy(gameObject);
            }
        }
    }
}
