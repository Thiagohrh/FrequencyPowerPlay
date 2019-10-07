using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoClipChanger : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public VideoClip[] videoSources;
    private int lastVideoIndex = -1;
    //Controls which band this script is going to listen to.
    public int bandIndex = 0;
    //Controls the sensitivity in order to check for a beat
    [Header("Beat Sensitivity values")]
    public float thresholdSensitivity = 0.5f;
    private float previousAudioValue = 0.0f;
    private float currentAudioValue = 0.0f;
    //Time control variables.
    public float timeBetweenBeats = 1.0f;
    private float beatTimer = 0.0f;

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
            beatTimer = timeBetweenBeats;
        }
        if (previousAudioValue <= thresholdSensitivity &&
            currentAudioValue > thresholdSensitivity &&
            beatTimer <= 0.0f)
        {
            SelectRandomVideo();
            beatTimer = timeBetweenBeats;
        }

        if (beatTimer > 0.0f)
        {
            beatTimer -= Time.deltaTime;
        }
    }

    private void SelectRandomVideo()
    {
        Debug.Log("BOOM!");
        videoPlayer.Stop();
        int randIndex = Random.Range(0, videoSources.Length - 1);
        if (randIndex == lastVideoIndex)
        {
            do
            {
                randIndex = Random.Range(0, videoSources.Length - 1);
            } while (randIndex == lastVideoIndex);
        }
        lastVideoIndex = randIndex;
        videoPlayer.clip = videoSources[randIndex];
        videoPlayer.Play();
    }
}
