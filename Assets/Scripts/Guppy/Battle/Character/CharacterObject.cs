using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class CharacterObject : MonoBehaviour
    {
        [SerializeField] private Transform battlePosition;
        [SerializeField] private Transform standbyPosition;
        private bool characterActive = false;

        void Start()
        {
            SetCharacterActive(false);
        }

        public void SetCharacterActive(bool state)
        {
            characterActive = state;
            if(state == true)
            {
                transform.position = battlePosition.position;
            }
            else
            {
                transform.position = standbyPosition.position;
            }
        }

        public bool IsCharacterActive()
        {
            return characterActive;
        }
    }

}
