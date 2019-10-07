using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleBandEmitter : MonoBehaviour {
    private ParticleSystem particleSystem;
    public int bandIndex = 1;
    //Controls the sensitivity in order to check for a beat
    [Header("Beat Sensitivity values")]
    public float thresholdSensitivity = 0.5f;
    private float previousAudioValue = 0.0f;
    private float currentAudioValue = 0.0f;
    //Time control variables.
    public float timeBetweenBeats = 1.0f;
    private float beatTimer = 0.0f;
    void Start () {
        particleSystem = GetComponent<ParticleSystem>();
	}
	
	void Update () {
        previousAudioValue = currentAudioValue;
        currentAudioValue = AudioSpecterSampler.frequencyBand[bandIndex];

        //if (previousAudioValue > thresholdSensitivity &&
        //    currentAudioValue <= thresholdSensitivity &&
        //    beatTimer <= 0.0f)
        //{
        //    particleSystem.Play();
        //    beatTimer = timeBetweenBeats;
        //}
        //if (previousAudioValue <= thresholdSensitivity &&
        //    currentAudioValue > thresholdSensitivity &&
        //    beatTimer <= 0.0f)
        //{
        //    particleSystem.Play();
        //    beatTimer = timeBetweenBeats;
        //}
        if (currentAudioValue - previousAudioValue > thresholdSensitivity &&
            currentAudioValue - previousAudioValue > 0)
        {
            particleSystem.Play();
            beatTimer = timeBetweenBeats;
        }

        if (beatTimer > 0.0f)
        {
            beatTimer -= Time.deltaTime;
        }
    }
}
