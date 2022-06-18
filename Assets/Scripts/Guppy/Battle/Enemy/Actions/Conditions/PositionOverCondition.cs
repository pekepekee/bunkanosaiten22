using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Enemy
{
    public class PositionOverCondition : EnemyActionCondition
    {
        private Vector2 targetPosition;

        public PositionOverCondition(Vector2 targetPosition)
        {
            this.targetPosition = targetPosition;
        }

        public bool IsValid(EnemyObject enemy)
        {
            Vector2 pos = enemy.GetPosition();
            if (pos.x >= targetPosition.x) return true;
            if (pos.y >= targetPosition.y) return true;

            return false;
        }
    }

}
