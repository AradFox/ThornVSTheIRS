using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    

    public Button start;
    public Button quit;

   

    public void LevelOneStart()
    {
        SceneManager.LoadScene("EscapingTheCloset");
    }

    public void TutorialStart()
    {
        SceneManager.LoadScene("WalkTutorial");
    }

    public void Quit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
