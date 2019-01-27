using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public void Initialize()
    {
        for (int i = 1; i < 9; i++)
        {
            PlayerPrefs.SetInt(GameConfig.Tags.Player + i.ToString(), 0);
        }
    }

    public void AddScore(int id, int score)
    {
        string key = GameConfig.Tags.Player + id.ToString();
        PlayerPrefs.SetInt(key, PlayerPrefs.GetInt(key, 0) + score);
        print(PlayerPrefs.GetInt(key, 0));
    }
}
