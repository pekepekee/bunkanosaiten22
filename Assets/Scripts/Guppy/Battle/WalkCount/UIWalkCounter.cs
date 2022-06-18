using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class UIWalkCounter : MonoBehaviour
    {
        [SerializeField] private Text counterText;
    
        public void UpdateUI(WalkCounter walkCounter)
        {
            counterText.text = $"‚Ì‚±‚è {(int)walkCounter.GetRemainingMeters()}m";
        }
    }
}
