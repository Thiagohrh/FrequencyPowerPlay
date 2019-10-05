using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoClipChanger : MonoBehaviour
{

    private VideoPlayer videoPlayer;
    public VideoClip[] videoSources;
    private int lastVideoIndex = -1;
    public int bandIndex = 0;
    public float thresholdSensitivity = 0.5f;
    public float timeBetweenBeats = 2.0f;

    private float beatTimer = 0.0f;


    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        SelectRandomVideo();
    }

    void Update()
    {

        if (AudioSpecterSampler.frequencyBand[bandIndex] > thresholdSensitivity && beatTimer <= 0.0f)
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
