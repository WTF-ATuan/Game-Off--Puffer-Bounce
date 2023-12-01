using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsEffects : MonoBehaviour
{
    [Header("..........................Audio Source")]
    [SerializeField] AudioSource Music;
    [SerializeField] AudioSource Sound;

    [Header(".....................Audio Clip")]
    public AudioClip background;

    public AudioClip PlayerShooting;
    public AudioClip EnemyDie;

    public AudioClip bossDie;

    public AudioClip wateryClick;

    public AudioClip bufferFishSwim;

    public AudioClip bossVoice;

    public AudioClip buferfishDash;
    public AudioClip collectItems;

    private void Start()
    {
        Music.clip = background;
        Music.Play();

    }
    public void PlaySFX(AudioClip clip)
    {
        Sound.PlayOneShot(clip);
    }
}
