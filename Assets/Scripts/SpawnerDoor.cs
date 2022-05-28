using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDoor : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float distanceOfPlayer;
    [SerializeField] private float radius, startTimer, time;
    [SerializeField] private bool loop;
    [SerializeField] private GameObject prefab;
    [Header("Если не  loop")]
    [SerializeField] private float delay;
    [SerializeField] private int count;

    private void Start()
    {
        if (!loop)
        {
            StartCoroutine(CorDelay());
            IEnumerator CorDelay()
            {
                yield return new WaitForSeconds(6f);
                for (int i = 0; i < count; i++)
                {
                    yield return new WaitForSeconds(delay);
                    Spawn();
                }
            }

        }
    }
    private void Update()
    {
        if (player)
        {
            var posSpawner = new Vector3(player.position.x
                , player.position.y,
                player.position.z + distanceOfPlayer);

            transform.position = posSpawner;

            if (loop)
            {
                time -= Time.deltaTime;
                if (time <= 0)
                {
                    Spawn();
                    time = startTimer;
                }
            }
        }
    }
    private void Spawn()
    {
        var rnd = RandomCircle(transform.position, Random.Range(0, radius));
        var obj = Instantiate(prefab, rnd, Quaternion.identity);
        obj.GetComponent<Door>().SetPlayer(player);
    }
    public Vector3 RandomCircle(Vector3 center, float radius)
    {
        var ang = Random.value * 360;
        Vector3 pos = new Vector3();
        pos.x = center.x + radius *Mathf.Sin(ang * Mathf.Deg2Rad); 
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z + radius * Mathf.Tan(ang * Mathf.Deg2Rad);
        return pos;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }
    public void RepeatStart()
    {
        Start();
    }
}
