using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class EffectKillAll : SpecialEffect
    {
        [SerializeField] private Transform enemiesTransform;
        [SerializeField] private AllEnemy allEnemy;

        public override void Execute()
        {
            allEnemy.Damage(9999);
        }
    }

}
