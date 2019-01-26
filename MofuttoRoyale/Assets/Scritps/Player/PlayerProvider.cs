using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProvider : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public Transform[] SpawnPoints;
    public int PlayerNumber = 4;
    void Start()
    {
        for (var id = 1; id <= PlayerNumber; id++)
        {
            Debug.Log("Player:" + id);
            var player = Instantiate(PlayerPrefab,SpawnPoints[id - 1]).GetComponent<BasePlayer>();
            player.GetComponent<BasePlayer>().SetPlayer(id);
            player.GetComponent<PlayerMover>().Set();
        }

    }
}
