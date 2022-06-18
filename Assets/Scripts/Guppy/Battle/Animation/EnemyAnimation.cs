using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class EnemyAnimation : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void Die()
        {
            animator.SetTrigger("Die");
        }
    }

}
