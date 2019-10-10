using System;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoClipChanger : MonoBehaviour
{
    [Header("Videos")]
    public VideoPlayer videoPlayer;
    public VideoClip[] videoSources;
    [Header("Manga Panels")]
    public MangaPanel[] panels;
    public int panelIndex = 0;
    public int lastVideoIndex = -1;
    //Controls which band this script is going to listen to.
    public int bandIndex = 0;
    //Controls the sensitivity in order to check for a beat
    [Header("Beat Sensitivity values")]
    public float thresholdSensitivity = 0.5f;
    public float previousAudioValue = 0.0f;
    public float currentAudioValue = 0.0f;
    //Time control variables.
    public float timeBetweenBeats = 1.0f;
    public float beatTimer = 0.0f;


    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        SelectRandomVideo();
    }

    void Update()
    {
        previousAudioValue = currentAudioValue;
        currentAudioValue = AudioSpecterSampler.frequencyBand[bandIndex];

        if (previousAudioValue > thresholdSensitivity && 
            currentAudioValue <= thresholdSensitivity &&
            beatTimer <= 0.0f)
        {
            SelectRandomVideo();
            MangaPanelClick();
            beatTimer = timeBetweenBeats;
        }
        if (previousAudioValue <= thresholdSensitivity &&
            currentAudioValue > thresholdSensitivity &&
            beatTimer <= 0.0f)
        {
            SelectRandomVideo();
            MangaPanelClick();
            beatTimer = timeBetweenBeats;
        }

        if (beatTimer > 0.0f)
        {
            beatTimer -= Time.deltaTime;
        }
    }

    private void MangaPanelClick()
    {
        panels[panelIndex].Click(timeBetweenBeats);
    }

    private void SelectRandomVideo()
    {
        //Debug.Log("BOOM!");
        videoPlayer.Stop();
        int randIndex = UnityEngine.Random.Range(0, videoSources.Length - 1);
        if (randIndex == lastVideoIndex)
        {
            do
            {
                randIndex = UnityEngine.Random.Range(0, videoSources.Length - 1);
            } while (randIndex == lastVideoIndex);
        }
        lastVideoIndex = randIndex;
        videoPlayer.clip = videoSources[randIndex];
        videoPlayer.Play();
    }
}
