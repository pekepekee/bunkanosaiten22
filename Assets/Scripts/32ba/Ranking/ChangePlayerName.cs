using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class ChangePlayerName : MonoBehaviour
{
    public void Change(string playerName)
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = playerName
        }, result =>
        {
            Debug.Log("プレイヤー名：" + result.DisplayName);
        }, error => Debug.LogError(error.GenerateErrorReport()));
    }
    public static bool IsValidateName(string name)
    {
        return !string.IsNullOrWhiteSpace(name)
               && 3 <= name.Length
               && name.Length <= 25;
    }
}
