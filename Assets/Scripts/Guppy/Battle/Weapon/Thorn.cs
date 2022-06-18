using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Thorn : MonoBehaviour
    {
        [SerializeField] private float attackTime = 0.3f;
        [SerializeField] private float destroyTime = 0.5f;
        [SerializeField] private Transform spriteTransform;
        [SerializeField] private Transform collisionTransform;
        [SerializeField] private float thornHeight;

        private Vector3 defaultCollisionPosition;

        private float progress;
        private float time;

        void Start()
        {
            defaultCollisionPosition = collisionTransform.localPosition;

            time = 0f;
            progress = 0f;

            //spriteTransform.localScale = GetSpriteScale(progress);
            collisionTransform.localPosition = GetCollisionPosition(progress);
        }

        void Update()
        {
            time += Time.deltaTime;
            progress = time / attackTime;

            if (time >= destroyTime)
            {
                Destroy(gameObject);
            }

            if (progress >= 1f)
            {
                //spriteTransform.localScale = new Vector3(1, 1, 1);
                collisionTransform.localPosition = defaultCollisionPosition;
            }
            else
            {
                //spriteTransform.localScale = GetSpriteScale(progress);
                collisionTransform.localPosition = GetCollisionPosition(progress);
            }
        }

        private Vector3 GetSpriteScale(float progress)
        {
            return new Vector3(1f, progress, 1f);
        }

        private Vector3 GetCollisionPosition(float progress)
        {
            return new Vector3(0f, -thornHeight * (1 - progress), 0f);
        }
    }
}
