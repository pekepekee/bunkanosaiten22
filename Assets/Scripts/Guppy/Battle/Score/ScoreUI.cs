using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Battle
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private Text scoreText;

        void Start()
        {
            UpdateScoreText(0);
        }

        public void UpdateScoreText(int score)
        {
            scoreText.text = score.ToString("D8");
        }
    }
}
