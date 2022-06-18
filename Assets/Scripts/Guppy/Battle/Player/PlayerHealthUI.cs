using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class PlayerHealthUI : MonoBehaviour
    {
        [SerializeField] private Slider hpSlider;

        public void UpdateUI(PlayerHealth health)
        {
            hpSlider.value = health.GetHealthPer();
        }
    }
}
