using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
   public class CircleGauge : MonoBehaviour
    {
        [SerializeField] private Image gaugeFillImage;
        [SerializeField] private Button specialButton;
        [SerializeField] private float maxFillAmount = 1f;

        private SpecialGauge referenceGauge = null;

        void Update()
        {
            UpdateGauge(referenceGauge);
            UpdateButton(referenceGauge);
        }

        public void SetSpecialGauge(SpecialGauge gauge, Sprite buttonImage)
        {
            referenceGauge = gauge;
            specialButton.image.sprite = buttonImage;
        }

        private void UpdateGauge(SpecialGauge gauge)
        {
            if(gauge == null)
            {
                SetValue(0f);
            }
            else
            {
                SetValue(gauge.GetGaugePer());
            }
        }

        private void UpdateButton(SpecialGauge gauge)
        {
            if(gauge == null)
            {
                specialButton.interactable = false;
            }
            else
            {
                specialButton.interactable = gauge.CanExecuteSkill();
            }
        }
        private void SetValue(float value)
        {
            gaugeFillImage.fillAmount = value * maxFillAmount;
        }
    }
}
