using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCntrler : SingletonBase<SceneCntrler>
{
    [SerializeField] private string nameSceneNext,Menu;
    [SerializeField] private string Lobby;
    public void LoadNextScene()
    {
        StartCoroutine(CorLoad());
        IEnumerator CorLoad()
        {
            yield return new WaitForSeconds(4f);
            SceneManager.LoadScene(nameSceneNext);
        }
    }
    public void LoadLobby()
    {
            SceneManager.LoadScene(Lobby);
    }
    public void LoadMenu()
    {
        StartCoroutine(CorLoad());
        IEnumerator CorLoad()
        {
            yield return new WaitForSeconds(8f);
            SceneManager.LoadScene(Menu);
        }
    }
    public void LoadMenuButton()
    {
            SceneManager.LoadScene(Menu);
    }
    public void LoadNextSceneMenuButton()
    {
            SceneManager.LoadScene(nameSceneNext);
      
    }
    public void Quit()
    {
        Application.Quit();
    }
}
