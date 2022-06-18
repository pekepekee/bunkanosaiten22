using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public abstract class CharacterWeapon : MonoBehaviour
    {
        public abstract void Attack(Vector3 attackPos);
    }
}
