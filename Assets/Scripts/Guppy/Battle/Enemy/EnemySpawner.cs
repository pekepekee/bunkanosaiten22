using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemy;
        [SerializeField] private float spawnTime = 1f;
        [SerializeField] private Transform spawnPos;
        [SerializeField] private Vector2 spawnPosGapMin;
        [SerializeField] private Vector2 spawnPosGapMax;
        [SerializeField] private Transform parent;

        private float time = 0f;
        [SerializeField] private bool spawnFlag = true;

        // Update is called once per frame
        void Update()
        {
            if (spawnFlag == false) return;

            time += Time.deltaTime;
            if(time >= spawnTime)
            {
                time = 0f;
                Spawn();
            }
        }

        public void StartSpawn()
        {
            spawnFlag = true;
        }

        public void StopSpawn()
        {
            spawnFlag = false;
        }

        public void Spawn()
        {
            Vector3 gap = new Vector3(Random.Range(spawnPosGapMin.x, spawnPosGapMax.y), Random.Range(spawnPosGapMin.y, spawnPosGapMax.y), 0f);
            Instantiate(enemy, spawnPos.position + gap, Quaternion.identity, parent);
        }
    }

}
