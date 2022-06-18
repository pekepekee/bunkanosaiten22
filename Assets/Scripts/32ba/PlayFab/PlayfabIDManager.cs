using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayfabIDManager : MonoBehaviour
{
    public static PlayfabIDManager Instance;
    
    /// <summary>
    /// 展示ビルドではこれを**必ず**trueにすること！！！！！！！！！！
    /// </summary>
    private bool _isExhibitionBuild = false;
    private string _guid;
    
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public string Get()
    {
        if (_isExhibitionBuild && _guid == "")
        { 
            _guid = Guid.NewGuid().ToString();
        }
        else
        {
            _guid = PlayerPrefs.GetString("PLAYFAB_CUSTOM_ID", Guid.NewGuid().ToString());
        }

        return _guid;
    }

    public void Set(string guid)
    {
        if (!_isExhibitionBuild)
        {
            PlayerPrefs.SetString("PLAYFAB_CUSTOM_ID", guid);
        }
    }
}
