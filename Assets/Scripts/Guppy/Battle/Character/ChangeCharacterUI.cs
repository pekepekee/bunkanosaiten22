using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class ChangeCharacterUI : MonoBehaviour
    {

        [SerializeField] private CharacterManager manager;

        public void OnPressButtonA()
        {
            manager.ChangeCharacter(CharacterID.PlayerA);
        }

        public void OnPressButtonM()
        {
            manager.ChangeCharacter(CharacterID.PlayerM);
        }

        public void OnPressButtonS()
        {
            manager.ChangeCharacter(CharacterID.PlayerS);
        }
    }

}
