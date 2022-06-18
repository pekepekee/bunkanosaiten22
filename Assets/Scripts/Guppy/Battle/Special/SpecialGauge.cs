using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class SpecialGauge
    {
        private float currentGaugeValue;
        private float maxGaugeValue;

        public SpecialGauge(float maxGaugeValue)
        {
            this.maxGaugeValue = maxGaugeValue;
            currentGaugeValue = 0f;
        }

        public void Add(float value)
        {
            currentGaugeValue = Mathf.Min(currentGaugeValue + value, maxGaugeValue);
        }

        public void Reset()
        {
            currentGaugeValue = 0f;
        }

        public bool CanExecuteSkill()
        {
            return currentGaugeValue >= maxGaugeValue;
        }

        public float GetGaugePer()
        {
            return currentGaugeValue / maxGaugeValue;
        }
    }
}
