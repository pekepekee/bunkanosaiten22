using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class BossSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject bossEnemy;
        [SerializeField] private Transform spawnPos;
        [SerializeField] private Transform parent;

        public void Spawn()
        {
            Instantiate(bossEnemy, spawnPos.position, Quaternion.identity, parent);
        }
    }

}
