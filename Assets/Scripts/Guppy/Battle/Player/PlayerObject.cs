using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class PlayerObject : MonoBehaviour
    {
        [SerializeField] private PlayerHealthUI healthUI;
        [SerializeField] private int maxHealth;

        private PlayerHealth health;

        void Awake()
        {
            health = new PlayerHealth(maxHealth);
        }

        void Start()
        {
            healthUI.UpdateUI(health);
        }

        public void Damage(int value)
        {
            if (health.IsDead()) return;

            health.Damage(value);
            healthUI.UpdateUI(health);

            if (health.IsDead())
            {
                Dead();
            }
        }

        private void Dead()
        {
            Debug.Log("GAME OVER");
        }

    }
}
