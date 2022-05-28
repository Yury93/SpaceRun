using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    [SerializeField] private float timeLive;
    private void Start()
    {
        Destroy(gameObject, timeLive);
    }

    void Update()
    {
        if(player)
        {
            rb.AddForce(-transform.forward * speed * Time.deltaTime);
        }
    }
    public void SetPlayer(Transform player)
    {
        this.player = player;
    }
    private void OnCollisionEnter(Collision collision)
    {
       var door = collision.gameObject.GetComponent<Door>();
       var inputMove = collision.gameObject.GetComponent<InputMove>();
        var asteroid = collision.gameObject.GetComponent<Obstacle>();
        if (door)
        {
            //EffectContainer.Instance.
            EffectContainer.Instance.DoorDestroy(collision.transform.position);
            
            Destroy(door.gameObject);
        }
        else if (inputMove)
        {
            if (GameManager.Instance.OffRopeFlag == false)
            {
                inputMove.SetSpeed(inputMove.Speed - 5f);
                EffectContainer.Instance.AsteroidDestroy(transform.position);
                AudioManager.Instance.PlayAudio("asteroid");
                Destroy(gameObject, 1);
            }
            else
            {
                EffectContainer.Instance.AsteroidDestroy(transform.position);
                AudioManager.Instance.PlayAudio("asteroid");
                GameManager.Instance.AsteroidCollision();
            }
        }
        else if (asteroid)
        {
            EffectContainer.Instance.AsteroidDestroy(collision.transform.position);
            Destroy(collision.gameObject);
        }
        else { Destroy(gameObject); }
       //TODO:«Õ¿◊»“≈À‹ÕŒ≈ «¿Ã≈ƒÀ≈Õ»≈ — Œ–Œ—“» »√–Œ ¿ ≈—À» “–Œ—— Õ¿Ã≈—“≈ »Õ¿◊≈ œŒÀ®“ »√–Œ ¿ ¬  Œ—ÃŒ—
       
    }
}
