using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class CharacterAttack : MonoBehaviour
    {
        [SerializeField] private int damage = 1;

        public void AddDamage(EnemyObject enemy)
        {
            enemy.Damage(damage);
        }
    }
}
