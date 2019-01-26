using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    private int _playerID;
    public int PlayerID { get { return _playerID; } }

    public void Initialize(int id)
    {
        _playerID = id;
    }
}
