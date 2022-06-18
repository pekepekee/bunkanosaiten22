using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Enemy
{
    public class SlimeActionExecutor : EnemyActionsExecutor
    {
        [SerializeField] private Vector2 moveVelocity;

        private EnemySimpleMove enemySimpleMove;

        void Start()
        {
            enemySimpleMove = new EnemySimpleMove(moveVelocity);
        }

        public override void ExecuteActions(EnemyObject enemy)
        {
            enemySimpleMove.Do(enemy);
        }
    }

}
