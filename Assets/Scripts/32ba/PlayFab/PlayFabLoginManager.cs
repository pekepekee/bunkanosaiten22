using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabLoginManager : MonoBehaviour
{
    [SerializeField] private GameObject errorWindowGameObject;

    private void Start()
    {
        PlayFabAuthService.Instance.Authenticate(Authtypes.Silent);
    }
    private void OnEnable()
    {
        PlayFabAuthService.OnLoginSuccess += PlayFabLogin_OnLoginSuccess;
        PlayFabAuthService.OnPlayFabError += PlayFabLogin_OnPlayFabError;
    }

    private void PlayFabLogin_OnPlayFabError(PlayFabError error)
    {
        Debug.LogError("Something Error...");
        errorWindowGameObject.GetComponent<ErrorWindowManager>().ShowErrorWindow(error.ToString());
    }

    private void PlayFabLogin_OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Login Success!");
        PlayFabAuthService.Instance.SaveCustomId();
    }
    
    private void OnDisable()
    {
        PlayFabAuthService.OnLoginSuccess -= PlayFabLogin_OnLoginSuccess;
        PlayFabAuthService.OnPlayFabError -= PlayFabLogin_OnPlayFabError;
    }
}