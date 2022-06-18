using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Battle;

public class ScoreObject : MonoBehaviour
{
    public static ScoreObject instance;

    private int totalScore;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void ResetScore()
    {
        totalScore = 0;
    }

    public void AddScore(Score score)
    {
        totalScore += score.GetValue();
    }

    public int GetTotalScore()
    {
        return totalScore;
    }
}