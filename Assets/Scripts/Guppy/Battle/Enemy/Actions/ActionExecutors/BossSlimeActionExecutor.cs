using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Enemy
{
    public class BossSlimeActionExecutor : EnemyActionsExecutor
    {
        enum State {
            INIT,
            WAIT,
            SUMMON,
            SHOOT
        }

        private State currentState;
        [SerializeField] private Vector2 firstMoveVelocity;
        [SerializeField] private float firstMoveTime;
        [SerializeField] private float waitTime = 3f;
        [SerializeField] private EnemySpawner slimeSpawner;

        private float currentWaitTime;

        void Start()
        {
            currentState = State.INIT;
            currentWaitTime = waitTime;
        }

        public override void ExecuteActions(EnemyObject enemy)
        {
            if(currentState == State.INIT)
            {
                if(firstMoveTime > 0f)
                {
                    firstMoveTime -= Time.deltaTime;
                    enemy.Move(firstMoveVelocity);
                }
                else
                {
                    currentState = State.WAIT;
                }

                return;
            }

            if(currentState == State.WAIT)
            {
                currentWaitTime -= Time.deltaTime;

                if(currentWaitTime < 0f)
                {
                    currentWaitTime = waitTime;

                    if(Random.value > 0.5f)
                    {
                        currentState = State.SHOOT;
                    }
                    else
                    {
                        currentState = State.SUMMON;
                    }
                }

                return;
            }

            if(currentState == State.SUMMON)
            {
                slimeSpawner.Spawn();

                Debug.Log("SUMMON");
                currentState = State.WAIT;
                return;
            }

            if (currentState == State.SHOOT)
            {
                Debug.Log("SHOOT");
                currentState = State.WAIT;
                return;
            }
        }
    }

}
