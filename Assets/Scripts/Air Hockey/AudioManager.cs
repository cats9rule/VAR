using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip PuckCollsion, Goal;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayPuckCollsion()
    {
        _audioSource.PlayOneShot(PuckCollsion);
    }

    public void PlayGoal()
    {
        _audioSource.PlayOneShot(Goal);
    }
}
