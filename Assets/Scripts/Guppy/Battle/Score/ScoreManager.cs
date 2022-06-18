using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager instance;

        void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
        }

        private ScoreBasic scoreKillEnemy;
        private ScoreBasic scoreDamageEnemy;

        [SerializeField] private ScoreUI scoreUI;
        [SerializeField] private int killEnemyScoreValue = 100;
        [SerializeField] private int damageEnemyScoreValue = 1;

        // Start is called before the first frame update
        void Start()
        {
            scoreKillEnemy = new ScoreBasic(killEnemyScoreValue);
            scoreDamageEnemy = new ScoreBasic(damageEnemyScoreValue);

            ScoreObject.instance.ResetScore();
        }

        public void OnKillEnemy()
        {
            scoreKillEnemy.AddCount(1);
            UpdateUI();
        }

        public void OnDamageEnemy(int value)
        {
            scoreDamageEnemy.AddCount(value);
            UpdateUI();
        }

        public void OnStageClear()
        {
            ScoreObject.instance.AddScore(scoreKillEnemy);
            ScoreObject.instance.AddScore(scoreDamageEnemy);
            Debug.Log(ScoreObject.instance.GetTotalScore());
        }

        private void UpdateUI()
        {
            int totalScore =
                scoreKillEnemy.GetValue() +
                scoreDamageEnemy.GetValue();

            scoreUI.UpdateScoreText(totalScore);
        }
    }
}
