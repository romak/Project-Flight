using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class RsMusicPlay : MonoBehaviour {

    public AudioClip[] musicClips;					//Array of music clips to play
    public AudioMixerSnapshot volumeDown;			//Reference to Audio mixer snapshot in which the master volume of main mixer is turned down
    public AudioMixerSnapshot volumeUp;				//Reference to Audio mixer snapshot in which the master volume of main mixer is turned up

    private AudioSource musicSource;				//Reference to the AudioSource which plays music

    void Awake()
    {
        musicSource = GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Start() {
        PlaySelectedMusic(0);
    }

    public void PlaySelectedMusic(int musicChoice)
    {
        //Play the music clip at the array index musicChoice
        musicSource.clip = musicClips[musicChoice];

        //Play the selected clip
        musicSource.Play();
    }

    //Call this function to very quickly fade up the volume of master mixer
    public void FadeUp(float fadeTime)
    {
        //call the TransitionTo function of the audioMixerSnapshot volumeUp;
        volumeUp.TransitionTo(fadeTime);
    }

    //Call this function to fade the volume to silence over the length of fadeTime
    public void FadeDown(float fadeTime)
    {
        //call the TransitionTo function of the audioMixerSnapshot volumeDown;
        volumeDown.TransitionTo(fadeTime);
    }

}
