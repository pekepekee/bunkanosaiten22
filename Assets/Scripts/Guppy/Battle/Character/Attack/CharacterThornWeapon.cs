using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class CharacterThornWeapon : CharacterWeapon
    {
        [SerializeField] private GameObject thorn;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float delay = 0f;

        public override void Attack(Vector3 attackPos)
        {
            StartCoroutine(DelayCoroutine(delay, () =>
            {
                attackPos.y = offset.y;
                attackPos.z = offset.z;

                Instantiate(thorn, attackPos, Quaternion.identity);
            }));
        }

        private IEnumerator DelayCoroutine(float seconds, Action action)
        {
            yield return new WaitForSeconds(seconds);
            action?.Invoke();
        }
    }
}
