using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering.PostProcessing;
public class DirectingScene : MonoBehaviour
{
    [SerializeField] private PostProcessVolume postProcess;
    private ChromaticAberration chromaticAberration;
    [SerializeField] private float chromaticSpeed;
    private float t;
    [SerializeField] private RopeController ropeController;
    private GameObject player;
    [SerializeField] private GameObject corridor;
    [SerializeField] private List<GameObject> playerInterface;
    [SerializeField] private GameObject buttonOffRope;
    [SerializeField] private float timerStartScene, timerStartGame;
    [SerializeField] private bool startScene,startGame;

    public void SetActiveUIPlayer(bool act)
    {
        foreach (var item in playerInterface)
        {
            item.SetActive(act);
        }
        buttonOffRope.SetActive(false);
    }
 
    private void Start()
    {
        postProcess.profile.TryGetSettings<ChromaticAberration>(out chromaticAberration);
        chromaticAberration.intensity.value = 1f;
        SetActiveUIPlayer(false);
        StartGame();
    }
    public void StartGame()
    {
        player = ropeController.GetPlayer.gameObject;
        
        if (player)
        {
            player.transform.DOMoveZ(15, 6);
            
            startScene = true;
        }
        else
        {
            Debug.Log("player не найден");
        }
    }
    private void Update()
    {
        if(startScene)//прикрепляемся к троссу
        {
            timerStartScene -= Time.deltaTime;
          
            if (timerStartScene <= 0)
            {
                player.GetComponentInChildren<Animator>().SetTrigger("Idle");
                StartCoroutine(CorDelay());
                IEnumerator CorDelay()
                {
                    yield return new WaitForSeconds(1.5f);
                    ropeController.OnRope();
                    startGame = true;
                    startScene = false;
                }
            }
        }
        if(startGame)
        {
            chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity.value, 0.038f, t);
            t = Time.deltaTime / chromaticSpeed;
            print(chromaticAberration.intensity.value);
            timerStartGame -= Time.deltaTime;
            if(timerStartGame <= 0)
            {
                StartCoroutine(CorDelayUiActive());
                IEnumerator CorDelayUiActive()
                {
                    yield return new WaitForSeconds(3f);
                    SetActiveUIPlayer(true);
                }
                startGame = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var pl = other.GetComponent<Player>();/*GetComponentInChildren<Animator>().SetTrigger("Jump");*/
        if(pl)
        {
            pl.GetComponentInChildren<Animator>().SetTrigger("Jump");
            Destroy(corridor, 3.5f);
        }
    }
}
