using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jump, death, restart;

    public void JumpSfx()
    {
        audioSource.clip = jump;
        audioSource.Play();
    }
    public void DeathSfx()
    {
        audioSource.clip = death;
        audioSource.Play();
    }
    public void RestartSfx()
    {
        audioSource.clip = restart;
        audioSource.Play();
    }
}
