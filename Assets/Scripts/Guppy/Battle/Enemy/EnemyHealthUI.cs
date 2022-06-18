using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class EnemyHealthUI : MonoBehaviour
    {
        [SerializeField] private GameObject healthBarObject;
        [SerializeField] private Slider hpSlider;
        [SerializeField] private float uiActiveTime = 1f;

        void Start()
        {
            healthBarObject.SetActive(false);
        }

        public void ShowUI(EnemyHealth health)
        {
            hpSlider.value = health.GetHealthPer();
            healthBarObject.SetActive(true);

            StartCoroutine(DelayMethod(uiActiveTime, () =>
            {
                healthBarObject.SetActive(false);
            }));
        }

        private IEnumerator DelayMethod(float waitTime, Action action)
        {
            yield return new WaitForSeconds(waitTime);
            action();
        }
    }
}
