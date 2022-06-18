using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class BattleAnimation : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        public void Attack()
        {
            animator.SetTrigger("Attack");
        }
    }
}
