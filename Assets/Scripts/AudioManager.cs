using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;
    public AudioClip flapAudio;
    public AudioClip hitAudio;
    public AudioClip pointAudio;
    public AudioClip dieAudio;
    private void Start()
    {
        instance = this;
    }

    public void PlayFlapAudio()
    {
        audioSource.PlayOneShot(flapAudio);
    }
    public void PlayHitAudio()
    {
        audioSource.PlayOneShot(hitAudio);
    }
    public void PlayPointAudio()
    {
        audioSource.PlayOneShot(pointAudio);
    }
    public void PlayDieAudio()
    {
        audioSource.PlayOneShot(dieAudio);
    }
}
