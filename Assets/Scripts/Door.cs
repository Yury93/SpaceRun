using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Transform player;
    public void SetPlayer(Transform player)
    {
        this.player = player;
    }
    private void OnTriggerEnter(Collider other)
    {
        var pl = other.GetComponent<Player>();
        if(pl)
        {
            EffectContainer.Instance.OnDoor(transform.position);
            AudioManager.Instance.PlayAudio("door");
            var inputPl = pl.GetComponent<InputMove>();
            inputPl.SetSpeed(inputPl.Speed + 50);
            ///прибавляем скорость как была и плюс толчок вперёд
            ///уничтожаем дверь
        }
    }
}
