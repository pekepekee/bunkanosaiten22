using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private bool onAttackDestory = false;
        [SerializeField] private int damage = 1;

        private bool disabled = false;

        public void AddDamage(PlayerObject player)
        {
            if (disabled) return;
            player.Damage(damage);
            if (onAttackDestory)
            {
                Destroy(gameObject);
            }
        }

        public void SetDisable(bool state)
        {
            disabled = state;
        }
    }

}
