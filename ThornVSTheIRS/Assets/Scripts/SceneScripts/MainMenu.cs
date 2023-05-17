using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI menuDiffTxt;
    public TextMeshProUGUI menuContTxt;

    public Button LevelTwoButton;
    public Button LevelThreeButton;

   

    public void LevelOneStart()
    {
        SceneManager.LoadScene("LevelOneScene");
    }

    public void Quit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
