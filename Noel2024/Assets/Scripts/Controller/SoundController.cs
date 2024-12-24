using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> onDeadClips;

    [SerializeField] private AudioClip completedClip;
    
    [SerializeField] private AudioClip jumpClip;
    
    private AudioSource source;
    private AudioClip currentClip;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GameManager.Instance.OnPlayerDeath += PlayDeadSound;
        GameManager.Instance.OnPlayerCompleted += PlayCompletedSound;
        GameManager.Instance.OnPlayerJumped += PlayJumpSound;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnPlayerDeath -= PlayDeadSound;
        GameManager.Instance.OnPlayerCompleted -= PlayCompletedSound;
        GameManager.Instance.OnPlayerJumped -= PlayJumpSound;
    }

    private void PlayDeadSound()
    {
        PlaySound(onDeadClips[randomDeadSound()]);
    }

    private void PlayCompletedSound()
    {
        PlaySound(completedClip);
    }

    private void PlayJumpSound()
    {
        PlaySound(jumpClip);
    }
    
    private void PlaySound(AudioClip clip)
    {
        if (clip == currentClip)
        {
            return;
        }
        source.PlayOneShot(clip);
    }
    private int randomDeadSound()
    {
        return new Random().Next(0, onDeadClips.Count);
    }
}
