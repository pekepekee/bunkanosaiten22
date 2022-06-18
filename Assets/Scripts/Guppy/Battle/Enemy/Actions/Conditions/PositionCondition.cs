using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Enemy
{
    public class PositionCondition : EnemyActionCondition
    {
        private Vector2 minPosition;
        private Vector2 maxPosition;

        public PositionCondition(Vector2 minPosition, Vector2 maxPosition)
        {
            this.minPosition = minPosition;
            this.maxPosition = maxPosition;
        }

        public bool IsValid(EnemyObject enemy)
        {
            Vector2 pos = enemy.GetPosition();
            if (pos.x < minPosition.x && pos.x > maxPosition.x) return false;
            if (pos.y < minPosition.y && pos.y > maxPosition.y) return false;

            return true;
        }
    }

}
