using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public static bool isGamePaused = false;
    [SerializeField] GameObject pauseMenuUI;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isGamePaused){
                Resume();             
            }else{
                Pause();
            }
        }
    }

    public void LoadNextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitApp(){
        Application.Quit();
    }

    public void LoadStartMenu(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void Resume(){
        Time.timeScale = 1f;
        isGamePaused = false;
        pauseMenuUI.SetActive(false);
    }

    public void Pause(){
        Time.timeScale = 0.0f;
        isGamePaused = true;
        pauseMenuUI.SetActive(true);
    }

}
