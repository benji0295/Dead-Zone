using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
  public TMP_Text livesText;

  private bool hasKey = false;
  private AudioSource audioSource;

  public AudioClip keySound;
  public AudioClip doorSound;

  // Start is called before the first frame update
  void Start()
  {
    audioSource = GetComponent<AudioSource>();

    livesText.text = "Lives: " + GameManager.lives;
  }

  // Update is called once per frame
  void Update()
  {

  }
  private void OnTriggerEnter(Collider collision)
  {
    if (collision.CompareTag("Key"))
    {
      hasKey = true;
      audioSource.PlayOneShot(keySound);
      Destroy(collision.gameObject);
    }
    if (collision.CompareTag("Door") && hasKey)
    {
      if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "LevelOne")
      {
        audioSource.PlayOneShot(doorSound);
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelTwo");
      }
      else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "LevelTwo")
      {
        audioSource.PlayOneShot(doorSound);
        UnityEngine.SceneManagement.SceneManager.LoadScene("WinScreen");
      }
    }
    if (collision.CompareTag("Zombie"))
    {
      GameManager.lives--;
      livesText.text = "Lives: " + GameManager.lives;
      if (GameManager.lives <= 0)
      {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoseScreen");
      }
    }
  }
}
