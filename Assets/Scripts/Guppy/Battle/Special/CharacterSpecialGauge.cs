using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class CharacterSpecialGauge : MonoBehaviour
    {
        [SerializeField] private Special special;
        [SerializeField] private int maxSpecialGauge = 100;

        private SpecialGauge specialGauge;

        void Start()
        {
            specialGauge = new SpecialGauge(maxSpecialGauge);
        }

        public void AddGauge(float value)
        {
            specialGauge.Add(value);
        }

        public void ExecuteSpecial()
        {
            if (specialGauge.CanExecuteSkill())
            {
                specialGauge.Reset();
                special.Execute();
            }
        }

        public void UpdateCircleGauge(CircleGauge gauge, Sprite buttonImage)
        {
            gauge.SetSpecialGauge(specialGauge, buttonImage);
        }

        public bool IsSpecialPlaying()
        {
            return special.IsMoviePlaying();
        }
    }

}
