using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class SpecialGaugeManager : MonoBehaviour
    {
        private CharacterID currentCharacter = CharacterID.NONE;

        [SerializeField] private CircleGauge circleGauge;

        [SerializeField] private CharacterSpecialGauge specialGauge_A;
        [SerializeField] private CharacterSpecialGauge specialGauge_M;
        [SerializeField] private CharacterSpecialGauge specialGauge_S;
        [SerializeField] private Sprite specialGaugeButtonSprite_A;
        [SerializeField] private Sprite specialGaugeButtonSprite_M;
        [SerializeField] private Sprite specialGaugeButtonSprite_S;

        [SerializeField] private float chargeSpeed = 1f;

        // Update is called once per frame
        void Update()
        {
            if (currentCharacter == CharacterID.PlayerM)
            {
                specialGauge_M.AddGauge(chargeSpeed * Time.deltaTime);
                specialGauge_M.UpdateCircleGauge(circleGauge, specialGaugeButtonSprite_M);
            }

            if (currentCharacter == CharacterID.PlayerA)
            {
                specialGauge_A.AddGauge(chargeSpeed * Time.deltaTime);
                specialGauge_A.UpdateCircleGauge(circleGauge, specialGaugeButtonSprite_A);
            }

            if (currentCharacter == CharacterID.PlayerS)
            {
                specialGauge_S.AddGauge(chargeSpeed * Time.deltaTime);
                specialGauge_S.UpdateCircleGauge(circleGauge, specialGaugeButtonSprite_S);
            }

            UpdateFreeze();
        }

        public void ChangeCharacter(CharacterID character)
        {
            currentCharacter = character;
        }

        public void OnClickSkillButton()
        {
            if (currentCharacter == CharacterID.PlayerM)
            {
                specialGauge_M.ExecuteSpecial();
            }

            if (currentCharacter == CharacterID.PlayerA)
            {
                specialGauge_A.ExecuteSpecial();
            }

            if (currentCharacter == CharacterID.PlayerS)
            {
                specialGauge_S.ExecuteSpecial();
            }
        }

        private void UpdateFreeze()
        {
            if (IsSpecialPlaying())
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

        private bool IsSpecialPlaying()
        {
            if (specialGauge_A.IsSpecialPlaying()) return true;

            if (specialGauge_M.IsSpecialPlaying()) return true;

            if (specialGauge_S.IsSpecialPlaying()) return true;

            return false;
        }
    }

}
