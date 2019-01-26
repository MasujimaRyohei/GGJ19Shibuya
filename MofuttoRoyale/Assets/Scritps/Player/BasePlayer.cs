using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlayer : MonoBehaviour
{
    private int _playerID;
    public int PlayerID { get { return _playerID; } }

    private IInputProvider _inputProvider;
    protected IInputProvider InputProvider { get { return _inputProvider; } }

    void Awake()
    {
        _inputProvider = GetComponent<IInputProvider>();
    }

    public void SetPlayer(int id)
    {
        _playerID = id;
        OnStart();
        Initialize();
    }


    protected abstract void OnStart();
    protected abstract void Initialize();
}
