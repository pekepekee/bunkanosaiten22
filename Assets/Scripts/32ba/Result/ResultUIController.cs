using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Battle;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultUIController : MonoBehaviour
{
    private int _score; 
    [SerializeField] private GameObject rankingUIObj;
    [SerializeField] private GameObject scoreUpdateUIObj;
    [SerializeField] private Text totalScoreText;

    private void Start()
    {
        _score = ScoreObject.instance.GetTotalScore();
        SetScores(_score);
        if (_score >= PlayerPrefs.GetInt("HIGH_SCORE"))
        {
            AsyncPopUpScoreSendWindow(3000);
        }
    }

    public void OnPushRankingButton()
    {
        rankingUIObj.SetActive(true);
    }

    public void OnPushHomeButton()
    {
        SceneManager.LoadScene("Scenes/Home");
    }

    public void OnPushRetryButton()
    {
        SceneManager.LoadScene("Scenes/BattleScene");
    }

    /// <summary>
    /// スコア送信画面を非同期で待って表示する。
    /// </summary>
    /// <param name="millisecond">ディレイ秒数(ミリ秒)</param>
    private async void AsyncPopUpScoreSendWindow(int millisecond)
    {
        await Task.Delay(millisecond);
        scoreUpdateUIObj.SetActive(true);
    }
    
    private void SetScores(int score)
    {
        totalScoreText.text = score.ToString();
    }

    /// <summary>
    /// スコア送信画面を非同期で待って表示する。
    /// </summary>
    /// <param name="millisecond">ディレイ秒数(ミリ秒)</param>
    private async void AsyncPopUpScoreSendWindow(int millisecond)
    {
        await Task.Delay(millisecond);
        scoreUpdateUIObj.SetActive(true);
    }
    
    private void SetScores(int score)
    {
        totalScoreText.text = score.ToString();
    }
}
