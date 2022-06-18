using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class CharacterKickWeapon : CharacterWeapon
    {
        [SerializeField] private GameObject kickAttack;
        [SerializeField] private Transform kickOffset;
        [SerializeField] private float delay = 0f;

        public override void Attack(Vector3 attackPos)
        {
            StartCoroutine(DelayCoroutine(delay, () =>
            {
                attackPos = kickOffset.position;

                attackPos.z = 0f;

                Instantiate(kickAttack, attackPos, Quaternion.identity);
            }));
        }

        private IEnumerator DelayCoroutine(float seconds, Action action)
        {
            yield return new WaitForSeconds(seconds);
            action?.Invoke();
        }
    }
}
