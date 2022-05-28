using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectContainer : SingletonBase<EffectContainer>
{
    [SerializeField] private GameObject asteroidDestroy,onDoor, doorDestroy;
    [SerializeField] private GameObject audioExplosion;
    public void AsteroidDestroy(Vector3 pos)
    {
        var effect = Instantiate(asteroidDestroy, pos, Quaternion.identity);
        var audio = Instantiate(audioExplosion, pos, Quaternion.identity);
        Destroy(audio, 3f);
        Destroy(effect, 5f);
    }
    public void OnDoor(Vector3 pos)
    {
        var effect = Instantiate(onDoor, pos, Quaternion.identity);
        Destroy(effect, 5f);
    }
    public void DoorDestroy(Vector3 pos)
    {
        var effect = Instantiate(doorDestroy, pos, Quaternion.identity);
        Destroy(effect, 5f);
    }
}
