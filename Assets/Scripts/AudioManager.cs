using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonBase<AudioManager>
{
    [SerializeField] private AudioSource asteroid, door, finish, lose, cableOn, cableOff;
    public void PlayAudio(string audio)
    {
        switch(audio)
        {
            case "asteroid":
                asteroid.Play();
                break;
            case "door":
                door.Play();
                break;
            case "finish":
                finish.Play();
                break;
            case "cableOn":
                cableOn.Play();
                break;
            case "cableOff":
                cableOff.Play();
                break;
            case "lose":
                lose.Play();
                break;
            default:
                break;
        }
    }
}
