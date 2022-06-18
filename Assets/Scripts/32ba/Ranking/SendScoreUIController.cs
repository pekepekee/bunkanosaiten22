using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class SendScoreUIController : MonoBehaviour
{
    private int _score;
    [SerializeField] private InputField playerNameInputField;
    [SerializeField] private Text scoreText;
    [SerializeField] private Button sendButton;
    [SerializeField] private GameObject errorWindowObject;

    private void OnEnable()
    {
        sendButton.interactable = false;
        _score = ScoreObject.instance.GetTotalScore();
        scoreText.text = "スコア : " + _score;
    }

    public void OnPushSendButton()
    {
        //ScoreManager.instance.SetScore(int.Parse(playerScoreInputField.text));
        //_score = ScoreManager.instance.GetScore();
        if(playerNameInputField.text.Length != 0)UpdatePlayerName(playerNameInputField.text);
        Send();
        gameObject.SetActive(false);
    }

    public void OnPushNotSendButton()
    {
        gameObject.SetActive(false);
    }

    private void Send()
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Ranking(Main)",
                    Value = _score,
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnUpdatePlayerStatisticsSuccess, OnUpdatePlayerStatisticsFailure);
    }
    
    private void OnUpdatePlayerStatisticsSuccess(UpdatePlayerStatisticsResult result)
    {
        Debug.Log($"スコア(統計情報)の更新が成功しました");
        PlayerPrefs.SetInt("HIGH_SCORE", _score);
        PlayerPrefs.Save();
    }
    
    private void OnUpdatePlayerStatisticsFailure(PlayFabError error){
        Debug.LogError($"スコア(統計情報)更新に失敗しました\n{error.GenerateErrorReport()}");
        errorWindowObject.GetComponent<ErrorWindowManager>().ShowErrorWindow(error.GenerateErrorReport());
    }

    public void OnPlayerNameInputFieldValueChanged()
    {
        sendButton.interactable = IsValidName(playerNameInputField.text);
    }
    
    /// <summary>
    /// プレイヤー名を変更する。
    /// </summary>
    /// <param name="playername">変更したいプレイヤー名</param>
    private void UpdatePlayerName(string playername)
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = playername
        };
        
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnUpdatePlayerNameSuccess, OnUpdatePlayerNameFailure);
    }

    private void OnUpdatePlayerNameSuccess(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("プレイヤー名：" + result.DisplayName);
    }

    private void OnUpdatePlayerNameFailure(PlayFabError error)
    {
        errorWindowObject.GetComponent<ErrorWindowManager>().ShowErrorWindow(error.GenerateErrorReport());
    }
    
    /// <summary>
    /// プレイヤー名が基準に適合しているかのValidator。
    /// </summary>
    /// <param name="name">判定したい名前</param>
    /// <returns>判定結果</returns>
    private static bool IsValidName(string name)
    {
        return !string.IsNullOrWhiteSpace(name)
               && 3 <= name.Length
               && name.Length <= 10;
    }
}
