using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RopeController : MonoBehaviour
{
    [SerializeField] private Player player;
    public Player GetPlayer => player;
    [SerializeField] private Transform pointRopePlayer;
    [SerializeField]private Transform pointRope;
    [SerializeField] private GameObject rope;
    private void Start()
    {
        rope.SetActive(false);
    }
    public void SetPlayer(Player player)
    {
        this.player = player;
        pointRopePlayer = player.GetComponentInChildren<TransformRopePlayer>().transform;
        pointRope = player.GetComponentInChildren<PointRope>().transform;
    }
    
    public void OnRope()
    {
        rope.SetActive(true);
        pointRope.DOMove(pointRopePlayer.position, 6f);
        StartCoroutine(CorOnRopeAudio());
        IEnumerator CorOnRopeAudio()
        {
            yield return new WaitForSeconds(6f);
            AudioManager.Instance.PlayAudio("cableOn");
        }
    }
    public void OffRope()
    {
        pointRope.DOMove(new Vector3(pointRopePlayer.position.x,
            pointRopePlayer.position.y-10,
            pointRopePlayer.position.z - 20), 5f);
        StartCoroutine(CorRopeDisable());
        IEnumerator CorRopeDisable()
        {
            yield return new WaitForSeconds(5.5f);
            rope.SetActive(false);
        }
    }
}
