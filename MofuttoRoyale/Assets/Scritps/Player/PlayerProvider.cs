using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProvider : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public Transform[] SpawnPoints;
    public int PlayerNumber;
    public bool isDebug = false;

    void Start()
    {
        CreatePlayer();
    }

    public void CreatePlayer()
    {
        if (isDebug)
        {
            Debug.Log("Debug");
            var player = Instantiate(PlayerPrefab, SpawnPoints[0]);
            player.GetComponent<PlayerCore>().Initialize(0);
        }
        else
        {
            for (var id = 1; id <= PlayerNumber; id++)
            {
                Debug.Log("Player:" + id);
                var player = Instantiate(PlayerPrefab, SpawnPoints[id - 1]);
                player.GetComponent<PlayerCore>().Initialize(id);
            }
        }
    }
}
