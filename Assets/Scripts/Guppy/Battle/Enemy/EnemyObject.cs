using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Battle.Enemy;

namespace Battle
{
    public class EnemyObject : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private int maxHealth = 1;
//        [SerializeField] private bool IsDestroyOnTime = true;
//        [SerializeField] private float destroyTime = 5f;
//        [SerializeField] private Vector2 moveVelocity;
        [SerializeField] private float maxOverkillTime = 0.5f;

        [SerializeField] private EnemyAnimation enemyAnimation;
        [SerializeField] private EnemyAttack enemyAttack;
        [SerializeField] private EnemyRB enemyRB;
        [SerializeField] private Vector2 knockBackForce = new Vector2(-400, 400);
        [SerializeField] private EnemyHealthUI enemyHealthUI;
        [SerializeField] private EnemyActionsExecutor enemyActionsExecutor;

        private EnemyHealth health;
        private float time;
        private float overKillTime;
        private bool overkillMode = false;

        void Start()
        {
            health = new EnemyHealth(maxHealth);
        }

        void Update()
        {
            if (overkillMode)
            {
                overKillTime -= Time.deltaTime;

                if (overKillTime <= 0f)
                {
                    ScoreManager.instance.OnStageClear();
                    Destroy(gameObject);
                }
            }
            else
            {
                rb2d.velocity = Vector2.zero;

                enemyActionsExecutor.ExecuteActions(this);
                time += Time.deltaTime;

                /*
                if (time >= destroyTime)
                {
                    Destroy(gameObject);
                }
                */
            }

        }

        public void Move(Vector2 velocity)
        {
            rb2d.velocity = velocity;
        }

        public void Damage(int value)
        {
            health.Damage(value);
            ScoreManager.instance.OnDamageEnemy(value);

            if (health.IsDead())
            {
                Die();
            }

            if (enemyHealthUI)
            {
                enemyHealthUI.ShowUI(health);
            }
        }

        private void Die()
        {
            if (enemyAttack)
            {
                enemyAttack.SetDisable(true);
            }

            overKillTime = maxOverkillTime;
            overkillMode = true;

            if(enemyAnimation != null)
            {
                enemyAnimation.Die();
            }

            if (enemyRB != null)
            {
                enemyRB.AddForce(knockBackForce);
            }

            ScoreManager.instance.OnKillEnemy();
        }

        public Vector2 GetPosition()
        {
            return transform.position;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            CharacterAttack characterAttack;

            collision.TryGetComponent<CharacterAttack>(out characterAttack);

            if (characterAttack)
            {
                characterAttack.AddDamage(this);
            }
        }
    }

}
