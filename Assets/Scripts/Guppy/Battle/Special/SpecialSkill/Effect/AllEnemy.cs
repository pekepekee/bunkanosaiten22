using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class AllEnemy : MonoBehaviour
    {
        [SerializeField] private Transform enemiesTransform;

        public void Damage(int value)
        {
            foreach(EnemyObject enemy in GetAllEnemies())
            {
                Debug.Log(enemy);
                enemy.Damage(value);
            }
        }

        public EnemyObject[] GetAllEnemies()
        {
            List<EnemyObject> enemies = new List<EnemyObject>();

            foreach (Transform obj in enemiesTransform)
            {
                EnemyObject enemy;

                if (obj.TryGetComponent<EnemyObject>(out enemy))
                {
                    enemies.Add(enemy);
                }
            }

            return enemies.ToArray();
        }
    }

}
