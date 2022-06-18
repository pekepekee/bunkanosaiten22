using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class PlayerHealth
    {
        private float maxHealth;
        private float currentHealth;

        public PlayerHealth(float maxHealth)
        {
            this.maxHealth = maxHealth;
            currentHealth = maxHealth;
        }

        public void Damage(float value)
        {
            currentHealth = Mathf.Max(0f, currentHealth - value);
        }

        public bool IsDead()
        {
            return currentHealth <= 0;
        }

        public float GetHealthPer()
        {
            return currentHealth / maxHealth;
        }
    }
}
