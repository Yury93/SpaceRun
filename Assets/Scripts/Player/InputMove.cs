using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMove : MonoBehaviour
{
    [SerializeField] private Joystick joystickVertical, joistickMove;
    [SerializeField] private float speed;
    public float Speed => speed;
    private float startSpeed;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startSpeed = speed;
    }
    void Update()
    {
        var directMove = new Vector3(joistickMove.Horizontal, joystickVertical.Vertical, joistickMove.Vertical);
        if (directMove.z < 0)
        {
            directMove.z = 0;
        }
        if (speed > 1)
        {
            speed -= Time.deltaTime;
        }
        else
        {
            speed = 1;
        }
        rb.AddForce(directMove * speed * Time.deltaTime, ForceMode.Impulse);
    }
   
    public void SetSpeed(float v)
    {
        speed = v;
    }
}
