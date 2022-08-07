using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int  score = 0;

    static ScoreKeeper instance;

    void Awake()
    {
        ManageSinglton();
    }

    void ManageSinglton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public float GetScore()
    {
        return score;
    }
    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);
    }
    public void ResetScore()
    {
        score = 0;
    }
}
