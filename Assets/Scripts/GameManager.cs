using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WrappingRopeLibrary.Scripts;
using DG.Tweening;
using Cinemachine;
using UnityEngine.UI;

public class GameManager : SingletonBase <GameManager>
{
    [SerializeField] private float generalTimer;
    [SerializeField] private Text timerTxt, resultTxt, lengthCableTxt, currentSpeedTxt;


    #region GAME_LOGIC
    [SerializeField] private CinemachineVirtualCamera cinemaCamera;
    [SerializeField] private Piece piece;
    public Piece RopePiece => piece;
    [SerializeField] private float limitLengthRope;
    [SerializeField] private GameObject player, uiController;
    [SerializeField] private InputMove inputMove;
    [SerializeField] private GameObject buttonOffRope;
    [SerializeField] private RopeController ropeController;
    [SerializeField] private SpawnerDoor spawnerDoor,spawnerDoor1,spawnerDoor2;
    private bool onLimitRope,offRope;
    public bool OffRopeFlag => offRope;
    private void Start()
    {
        limitLengthRope = Random.Range(80, 120);
        inputMove = player.GetComponent<InputMove>();
        resultTxt.gameObject.SetActive(false);
        lengthCableTxt.gameObject.SetActive(false);
    }
    private void Update()
    {
        currentSpeedTxt.text =$"Maximum speed: {((int)inputMove.Speed).ToString()}";
        if(onLimitRope == false && limitLengthRope <= piece.Length)
        {
            lengthCableTxt.gameObject.SetActive(true);
            lengthCableTxt.text = "Ultimate cable length!";
            OnLimitRope();
            onLimitRope = true;
        }
        
        if (generalTimer<0)
        {
            AudioManager.Instance.PlayAudio("lose");
            timerTxt.text = "TIME:0";
            resultTxt.gameObject.SetActive(true);
            resultTxt.text = "Time has expired. Too slow. You lost!";
            SceneCntrler.Instance.LoadMenu();
        }
        else
        {
            generalTimer -= Time.deltaTime;
            timerTxt.text = $"TIME:{(int)generalTimer}";
        }
    }
    public void OnLimitRope()
    {
        buttonOffRope.SetActive(true);
        player.GetComponent<InputMove>().SetSpeed(1);
    }
    public void OffRope()
    {
        AudioManager.Instance.PlayAudio("cableOff");
        player.transform.DOMove(player.transform.position + Vector3.forward, 1f);
        ropeController.OffRope();
        inputMove.SetSpeed(80);
        spawnerDoor.RepeatStart();
        spawnerDoor1.RepeatStart();
        spawnerDoor2.RepeatStart();
        buttonOffRope.SetActive(false);
        lengthCableTxt.gameObject.SetActive(false);
        offRope = true;
    }
    public void AsteroidCollision()
    {
        AudioManager.Instance.PlayAudio("lose");
        cinemaCamera.Follow = null;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        uiController.SetActive(false);

        resultTxt.gameObject.SetActive(true);
        resultTxt.text = "An asteroid hit you! You lost!";
        SceneCntrler.Instance.LoadMenu();
        print("конкретный проигрышь");
    }
    public void WinGame()
    {
        AudioManager.Instance.PlayAudio("finish");
        resultTxt.gameObject.SetActive(true);
        resultTxt.text = "You won because you're the best!";
        SceneCntrler.Instance.LoadNextScene();
    }
    #endregion
}
