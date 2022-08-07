using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;
    [SerializeField] float gameLoadDelay = 2f;
    ScoreKeeper scoreKeeper;


    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGame()

    {
        scoreKeeper.ResetScore();
        StartCoroutine(WaitandLoad("Game", gameLoadDelay));

    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitandLoad("GameOver", sceneLoadDelay));
    }
    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();        
    }
    IEnumerator WaitandLoad(string sceneName,float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
