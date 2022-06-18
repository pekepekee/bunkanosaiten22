using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SpecialMovie : MonoBehaviour
{
    [SerializeField] private GameObject videoOutput;
    [SerializeField] private VideoPlayer videoPlayer;

    public bool playing { get; private set; } = false;

    void Start()
    {
        videoPlayer.loopPointReached += LoopPointReached;
    }

    void Update()
    {
        if (playing)
        {
            videoOutput.SetActive(true);
        }
        else
        {
            videoOutput.SetActive(false);
        }
    }

    public void Play()
    {
        videoPlayer.time = 0f;
        videoPlayer.Play();
        playing = true;
    }

    public void LoopPointReached(VideoPlayer vp)
    {
        playing = false;
    }
}
