using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Enemy
{
    public class EnemySimpleMove : EnemyAction
    {
        private Vector2 velocity;

        public EnemySimpleMove(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        public void Do(EnemyObject target)
        {
            target.Move(velocity);
        }
    }

}
