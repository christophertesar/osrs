using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<AudioClip> songs;
    public AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = songs[Random.Range(0, songs.Count)];
        audioSource.Play();
        Invoke("playRandomSong", audioSource.clip.length + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playRandomSongOverride(){
        audioSource.clip = songs[Random.Range(0, songs.Count)];
        audioSource.Play();
        Invoke("playRandomSong", audioSource.clip.length + 1);
    }

    public void playRandomSong(){
        if(!audioSource.isPlaying){
            audioSource.clip = songs[Random.Range(0, songs.Count)];
            audioSource.Play();
            Invoke("playRandomSong", audioSource.clip.length + 1);
        }
    }
}
