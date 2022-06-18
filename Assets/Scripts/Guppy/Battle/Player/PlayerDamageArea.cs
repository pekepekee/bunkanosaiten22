using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class PlayerDamageArea : MonoBehaviour
    {
        [SerializeField] private PlayerObject player;

        void OnTriggerEnter2D(Collider2D collision)
        {
            EnemyAttack enemyAttack;

            collision.TryGetComponent<EnemyAttack>(out enemyAttack);

            if(enemyAttack != null)
            {
                enemyAttack.AddDamage(player);
            }
        }
    }
}
