using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject uiController;

    private void OnTriggerEnter(Collider other)
    {
        var pl = other.GetComponent<InputMove>();
        if(pl)
        {
            uiController.SetActive(false);
            GameManager.Instance.WinGame();
            print("победа!");
        }
    }
}
