using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{ private bool isPaused = false;
    public GameObject pauseMenu;
    void Update()
    { if (Input.GetKeyDown(KeyCode.Escape))
        
      if (isPaused)
      {
        ResumeGame();
      }
    else
      {
        PauseGame();
      }





    }



     void PauseGame()
     {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
     }
     void ResumeGame()
     {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
     }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    
    public void play()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }   
}







