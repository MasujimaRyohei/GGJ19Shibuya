using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProvider : MonoBehaviour
{
    public GameObject[] PlayerPrefabs;
    public Transform[] SpawnPoints;
    public int PlayerNumber;
    private int[] playerTypeNum;
    public bool isDebug = false;

    void Start()
    {
        CreatePlayer();
    }

    public void CreatePlayer()
    {
        RandomSetPlayerType();
        if (isDebug)
        {
            Debug.Log("Debug");
            var player = Instantiate(PlayerPrefabs[0], SpawnPoints[0]);
            player.GetComponent<PlayerCore>().Initialize(0);
        }
        else
        {
            for (var id = 1; id <= PlayerNumber; id++)
            {
                var playerType = playerTypeNum[id - 1];
                Debug.Log("Player:" + id + "PlayerType:" + playerType);
                var player = Instantiate(PlayerPrefabs[playerType], SpawnPoints[id - 1]);
                player.GetComponent<PlayerCore>().Initialize(id);
            }
        }
    }

    private void RandomSetPlayerType()
    {
        playerTypeNum = new int[PlayerNumber];
        int random = Random.Range(0,PlayerNumber);
        for (int i = 0; i < PlayerNumber; i++)
        {
            playerTypeNum[i] = i;
        }
        for (int i = 0; i < PlayerNumber; i++)
        {
            int temp = playerTypeNum[i];
            playerTypeNum[i] = playerTypeNum[random];
            playerTypeNum[random] = temp;
        }
    }
}

public enum PlayerType
{
    Dog = 0,
    Hiyoko = 1,
    Usagi = 2,
    Zou = 3
}
