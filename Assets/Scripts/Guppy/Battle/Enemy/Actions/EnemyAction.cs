using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Enemy
{
    public interface EnemyAction
    {
        public void Do(EnemyObject enemy);
    }

}
