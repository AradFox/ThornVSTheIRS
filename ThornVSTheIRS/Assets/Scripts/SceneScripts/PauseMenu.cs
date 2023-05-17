using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    Canvas cv;

    void Start()
    {
        cv = GetComponent<Canvas>();
        cv.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                cv.enabled = true;
            }
            else if (Time.timeScale == 0)
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        cv.enabled = false;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

}
