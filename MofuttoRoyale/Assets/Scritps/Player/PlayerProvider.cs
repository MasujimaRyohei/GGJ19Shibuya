using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProvider : MonoBehaviour
{
    public GameObject[] PlayerPrefabs;
    public Transform[] SpawnPoints;
    public int PlayerNumber;
    private int[] playerTypeNumbers;
    public bool isDebug = false;

    void Start()
    {
        CreatePlayer();
    }

    public void CreatePlayer()
    {
        if (isDebug)
        {
            var player = Instantiate(PlayerPrefabs[0], SpawnPoints[0].position, Quaternion.LookRotation(Vector3.back));
            player.GetComponent<PlayerCore>().InitializePlayer(0, PlayerType.Dog, SpawnPoints[0].position);
        }
        else
        {
            RandomSetPlayerType();
            for (var id = 0; id < PlayerNumber; id++)
            {
                var playerTypeNum = playerTypeNumbers[id];
                var playerType = ConvertEnum.ConvertToEnum<PlayerType>(playerTypeNum);
                var player = Instantiate(PlayerPrefabs[playerTypeNum], SpawnPoints[id].position, Quaternion.LookRotation(Vector3.back));
                player.GetComponent<PlayerCore>().InitializePlayer(id, playerType, SpawnPoints[id].position);
            }
        }
    }

    private void RandomSetPlayerType()
    {
        playerTypeNumbers = new int[PlayerNumber];
        int random = Random.Range(0, PlayerNumber);
        for (int i = 0; i < PlayerNumber; i++)
        {
            playerTypeNumbers[i] = i;
        }
        for (int i = 0; i < PlayerNumber; i++)
        {
            int temp = playerTypeNumbers[i];
            playerTypeNumbers[i] = playerTypeNumbers[random];
            playerTypeNumbers[random] = temp;
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
