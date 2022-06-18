using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Enemy
{
    public interface EnemyActionCondition
    {
        public bool IsValid(EnemyObject enemy);
    }

}
