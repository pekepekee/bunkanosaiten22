using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class CharacterShooter : MonoBehaviour
    {
        [SerializeField] private CharacterObject characterObj;
        [SerializeField] private CharacterWeapon weaponObject;
        [SerializeField] private BattleAnimation battleAnimation;
        [SerializeField] private float maxCoolTime = 0f;

        float coolTime = 0f;

        void Update()
        {
            if (Input.GetMouseButton(0) && characterObj.IsCharacterActive())
            {
                if (coolTime <= 0f)
                {
                    Vector2 mousePos = Input.mousePosition;

                    if (CanAttack(mousePos))
                    {
                        Attack(mousePos);
                    }
                }
            }

            coolTime = Mathf.Max(0f, coolTime - Time.deltaTime);
        }

        public bool CanAttack(Vector2 mousePos)
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 100f);

            if(hit.collider && hit.collider.CompareTag("EnemiesArea"))
            {
                return true;
            }

            return false;
        }

        public void Attack(Vector2 mousePos)
        {
            coolTime = maxCoolTime;

            Vector3 attackPos = Camera.main.ScreenToWorldPoint(mousePos);
            weaponObject.Attack(attackPos);

            if (battleAnimation)
            {
                battleAnimation.Attack();
            }
        }
    }
}
