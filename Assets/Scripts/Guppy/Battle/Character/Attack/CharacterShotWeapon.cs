using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class CharacterShotWeapon : CharacterWeapon
    {
        [SerializeField] private Transform fromTransform;
        [SerializeField] private GameObject bullet;
        [SerializeField] private float shotForce;
        [SerializeField] private float delay = 0f;

        public override void Attack(Vector3 attackPos)
        {
            StartCoroutine(DelayCoroutine(delay, () =>
            {
                GameObject instance = Instantiate(bullet, fromTransform.position, Quaternion.identity);


                attackPos.z = 0f;

                Vector3 direction = (attackPos - fromTransform.position).normalized;

                instance.transform.rotation = Quaternion.FromToRotation(Vector3.left, direction);

                instance.GetComponent<Rigidbody2D>().AddForce(shotForce * direction);
            }));
        }

        private IEnumerator DelayCoroutine(float seconds, Action action)
        {
            yield return new WaitForSeconds(seconds);
            action?.Invoke();
        }
    }

}
