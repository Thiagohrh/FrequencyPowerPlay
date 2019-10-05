using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSpecterSampler : MonoBehaviour
{
    AudioSource audioSource;
    public static float[] samples = new float[512];
    public static float[] frequencyBand = new float[8];

    private FrequencyConverter frequencyConverter;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        frequencyConverter = new FrequencyConverter();
    }

    void Update()
    {
        GetSpectrumAudioSource();
        frequencyBand = frequencyConverter.ConvertToBands(samples);
    }

    private void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Hamming);
    }
}
