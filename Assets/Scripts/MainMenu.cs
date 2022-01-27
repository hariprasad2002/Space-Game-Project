using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]private AudioClip clip;
    [SerializeField]private AudioSource source;
    void Start()
    {
        source.PlayOneShot(clip);
    }
    public void pauseGame()
    {
        Time.timeScale=0;
    }
    public void resumeGame()
    {
        Time.timeScale=1;
    }
    public void restartGame()
    {
        Time.timeScale=1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BackGame()
    {
        Time.timeScale=1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closing!!!");
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
