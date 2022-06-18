using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class RankingUIController : MonoBehaviour
{
    [SerializeField] private GameObject rankingContentPanelPref;
    [SerializeField] private GameObject rankingScrollViewContentObj;

    private void OnEnable()
    {
        PlayFabClientAPI.GetLeaderboard(
            new GetLeaderboardRequest
            {
                StatisticName = "Ranking(Main)",
                StartPosition = 0,
                MaxResultsCount = 100
            },
            result =>
            {
                foreach (var ranking in result.Leaderboard)
                {
                    Instantiate(rankingContentPanelPref, rankingScrollViewContentObj.transform)
                        .GetComponent<RankingContentPanelManager>()
                        .Set(ranking.Position+1, ranking.DisplayName, ranking.StatValue);
                }
            },
            error =>
            {
                Debug.Log(error.GenerateErrorReport());
            }
        );
    }

    private void OnDisable()
    {
        foreach (Transform n in rankingScrollViewContentObj.transform)
        {
            Destroy(n.gameObject);
        }
    }

    public void OnPushBackButton()
    {
        gameObject.SetActive(false);
    }
}
