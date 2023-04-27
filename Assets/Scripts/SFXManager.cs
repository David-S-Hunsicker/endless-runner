using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coinSFX;
    public void PlaySFX(string clipToPlay)
    {
        if (clipToPlay == "Coin")
        {
            audioSource.clip = coinSFX;

        }
        audioSource.Play();
    }
}
