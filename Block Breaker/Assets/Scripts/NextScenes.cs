using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextScenes : MonoBehaviour
{
    public void NextScene()
    {
        int active_scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(active_scene + 1);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<GameStatus>().ResetScoreDestroyItself();
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

}
