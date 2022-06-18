using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Enemy
{
    public abstract class EnemyActionsExecutor : MonoBehaviour
    {
        public abstract void ExecuteActions(EnemyObject enemy);
    }

}
