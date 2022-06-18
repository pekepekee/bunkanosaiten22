using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public enum CharacterID
    {
        NONE,
        PlayerA,
        PlayerM,
        PlayerS
    }

    public class CharacterManager : MonoBehaviour
    {
        public CharacterID activeCharacter { get; private set; }

        [SerializeField] private SpecialGaugeManager specialGaugeManager;
        [SerializeField] private CharacterObject playerA;
        [SerializeField] private CharacterObject playerM;
        [SerializeField] private CharacterObject playerS;

        void Start()
        {
            ChangeCharacter(CharacterID.NONE);
        }

        public void ChangeCharacter(CharacterID character)
        {
            activeCharacter = character;
            specialGaugeManager.ChangeCharacter(character);

            playerA.SetCharacterActive(false);
            playerM.SetCharacterActive(false);
            playerS.SetCharacterActive(false);

            if (character == CharacterID.PlayerA)
            {
                playerA.SetCharacterActive(true);
            }

            if (character == CharacterID.PlayerM)
            {
                playerM.SetCharacterActive(true);
            }

            if (character == CharacterID.PlayerS)
            {
                playerS.SetCharacterActive(true);
            }
        }
    }
}
