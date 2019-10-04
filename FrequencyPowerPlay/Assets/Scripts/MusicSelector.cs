using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicSelector : MonoBehaviour {

    public AudioClip[] musics;
    private AudioSource audioSource;
	void Start () 
    {
        audioSource = GetComponent<AudioSource>();
        SelectRandomTrack();
	}

    void SelectRandomTrack() 
    {
        audioSource.Stop();
        int randIndex = Random.Range(0, musics.Length - 1);
        audioSource.clip = musics[randIndex];
        audioSource.Play();
    }
}
