using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
  void Update()
  {
    if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "MainMenu")
    {
      if (Input.GetKeyDown(KeyCode.Return))
      {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelOne");
      }
    }
    else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "WinScreen" || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "LoseScreen")
    {
      if (Input.GetKeyDown(KeyCode.Return))
      {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
      }
    }
  }
}