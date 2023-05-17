using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenTteleporter : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("LevelOneScene");
    }
}
