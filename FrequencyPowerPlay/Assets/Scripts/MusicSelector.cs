using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MusicSelector : MonoBehaviour
{
    public AudioClip[] musics;
    public Text musicLabel;
    private AudioSource audioSource;
    private int lastMusicIndex = -1;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SelectRandomTrack();
    }

    public void SelectRandomTrack() //In case you feel like CHANGING THE TUUUUUUUUNES.
    {
        audioSource.Stop();
        int randIndex = Random.Range(0, musics.Length - 1);
        if (randIndex == lastMusicIndex)
        {
            do
            {
                randIndex = Random.Range(0, musics.Length - 1);
            } while (randIndex == lastMusicIndex);
        }
        lastMusicIndex = randIndex;
        audioSource.clip = musics[randIndex];
        audioSource.Play();

        musicLabel.text = audioSource.clip.name;
    }
}
