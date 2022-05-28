using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPersAnimation : MonoBehaviour
{
    [SerializeField] private AudioSource run,jump;
    public void OnPlayAudioRun()
    {
        run.Play();
    }
    public void OnPlayAudioJump()
    {
        jump.Play();
    }
}
