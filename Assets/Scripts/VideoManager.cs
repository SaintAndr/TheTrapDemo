using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;

    public VideoPlayer introVideoPlayer;
    public VideoPlayer outroVideoPlayer;

    private void Start()
    {
        PlayIntroVideo();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && introVideoPlayer.isPlaying)
        {
            SkipIntroVideo();
        }

        if (Input.GetKeyDown(KeyCode.Space) && outroVideoPlayer.isPlaying)
        {
            ExitGame();
        }
    }

    private void PlayIntroVideo()
    {
        introVideoPlayer.Play();
        introVideoPlayer.loopPointReached += OnIntroVideoFinished;
    }

    private void OnIntroVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(2);
    }

    private void SkipIntroVideo()
    {
        introVideoPlayer.Stop();
        SceneManager.LoadScene(2);
    }

    public void PlayOutroVideo()
    {
        outroVideoPlayer.Play();
        outroVideoPlayer.loopPointReached += OnOutroVideoFinished;
    }

    private void OnOutroVideoFinished(VideoPlayer vp)
    {
        ExitGame();
    }

    private void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
