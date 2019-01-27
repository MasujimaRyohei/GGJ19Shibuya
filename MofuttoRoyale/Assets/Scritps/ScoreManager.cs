using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ScoreManager : MonoBehaviour
{
    IntReactiveProperty[] playerScore = new IntReactiveProperty[GameConfig.PlayerMax];
    public void Initialize()
    {
        for (int i = 0; i < GameConfig.PlayerMax; i++)
        {
            playerScore[i].Value = 0;
            PlayerPrefs.SetInt(GameConfig.Tags.Player + i.ToString(), 0);
        }
    }

    public void AddScore(int id, int score)
    {
        playerScore[id-1].Value += score;
        string key = GameConfig.Tags.Player + id.ToString();
        PlayerPrefs.SetInt(key, PlayerPrefs.GetInt(key, 0) + score);
        print(PlayerPrefs.GetInt(key, 0));
    }
}
