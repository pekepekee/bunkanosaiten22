using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingContentPanelManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text nameText;
    [SerializeField] private Text rankText;

    /// <summary>
    /// パネルに名前を反映する
    /// </summary>
    /// <param name="rank">順位</param>
    /// <param name="playerName">プレイヤー名</param>
    /// <param name="score">スコア</param>
    public void Set(int rank, string playerName, int score)
    {
        rankText.text = rank + "位";
        nameText.text = playerName;
        scoreText.text = score.ToString();
    }
}
