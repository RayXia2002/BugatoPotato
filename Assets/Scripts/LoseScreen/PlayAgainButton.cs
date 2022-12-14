using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{
    public GameObject levelLoader;
    void Awake()
    {
        levelLoader.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
