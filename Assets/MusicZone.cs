using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZone : MonoBehaviour
{
    // Start is called before the first frame update
    public List<AudioClip> music;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            AudioController audioController = other.GetComponent<AudioController>();
            audioController.songs = new List<AudioClip>(music);
            audioController.playRandomSongOverride();
        }
    }

    
}
