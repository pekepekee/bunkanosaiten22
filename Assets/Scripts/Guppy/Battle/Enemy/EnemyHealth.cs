using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class EnemyHealth
    {
        public float maxHealth { get; private set; }
        public float health { get; private set; }

        public EnemyHealth(int maxHealth)
        {
            this.maxHealth = maxHealth;
            this.health = maxHealth;
        }

        public bool IsDead()
        {
            return health <= 0;
        }

        public void Damage(int value)
        {
            health -= value;
        }

        public float GetHealthPer()
        {
            return health / maxHealth;
        }
    }
}
