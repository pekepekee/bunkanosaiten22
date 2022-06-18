using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ErrorWindowManager : MonoBehaviour
{
    [SerializeField] private Text variableText;

    private void OnDisable()
    {
        variableText.text = "";
    }

    public void OnClickReturnButton()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// エラーウィンドウ表示用の関数。
    /// </summary>
    /// <param name="errorText">表示するエラー文</param>
    public void ShowErrorWindow(string errorText)
    {
        variableText.text = errorText;
        gameObject.SetActive(true);
    }
}
