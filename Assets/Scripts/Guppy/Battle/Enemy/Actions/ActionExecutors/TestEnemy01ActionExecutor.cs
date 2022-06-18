using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Enemy
{
    enum TestEnemy01ActionState
    {
        InitMove,
        Move_UP,
        Move_DOWN
    }

    public class TestEnemy01ActionExecutor : EnemyActionsExecutor
    {
        [SerializeField] private float move1Time = 6f;
        [SerializeField] private float move2Time_UP = 2f;
        [SerializeField] private float move2Time_DOWN = 2f;

        [SerializeField] private Vector2 move1_Velocity;
        [SerializeField] private Vector2 move2_Velocity_UP;
        [SerializeField] private Vector2 move2_Velocity_DOWN;

        private EnemySimpleMove enemySimpleMove1;
        private EnemySimpleMove enemySimpleMove2_UP;
        private EnemySimpleMove enemySimpleMove2_DOWN;

        private float moveTime;
        private float deltaTime;

        private TestEnemy01ActionState state;

        void Start()
        {
            enemySimpleMove1 = new EnemySimpleMove(move1_Velocity);
            enemySimpleMove2_UP = new EnemySimpleMove(move2_Velocity_UP);
            enemySimpleMove2_DOWN = new EnemySimpleMove(move2_Velocity_DOWN);

            state = TestEnemy01ActionState.InitMove;
            moveTime = move1Time;
        }

        void Update()
        {
            deltaTime += Time.deltaTime;
        }

        public override void ExecuteActions(EnemyObject enemy)
        {
            if(state == TestEnemy01ActionState.InitMove)
            {
                enemySimpleMove1.Do(enemy);
            }
            
            if(state == TestEnemy01ActionState.Move_UP)
            {
                enemySimpleMove2_UP.Do(enemy);
            }
            
            if (state == TestEnemy01ActionState.Move_DOWN)
            {
                enemySimpleMove2_DOWN.Do(enemy);
            }

            moveTime -= deltaTime;
            deltaTime = 0f;

            if (moveTime <= 0f)
            {
                if (state == TestEnemy01ActionState.InitMove)
                {
                    state = TestEnemy01ActionState.Move_UP;
                    moveTime = move2Time_UP;
                }
                else if (state == TestEnemy01ActionState.Move_UP)
                {
                    state = TestEnemy01ActionState.Move_DOWN;
                    moveTime = move2Time_DOWN;
                }
                else if (state == TestEnemy01ActionState.Move_DOWN)
                {
                    state = TestEnemy01ActionState.Move_UP;
                    moveTime = move2Time_UP;
                }

            }
        }
    }

}
