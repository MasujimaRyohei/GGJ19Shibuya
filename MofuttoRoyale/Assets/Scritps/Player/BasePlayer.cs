using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlayer : MonoBehaviour
{
    protected PlayerCore PlayerCore;
    protected int PlayerID { get { return PlayerCore.PlayerID; } }

    private IInputProvider _inputProvider;
    protected IInputProvider InputProvider { get { return _inputProvider; } }

    void Start()
    {
        PlayerCore = GetComponent<PlayerCore>();
        _inputProvider = GetComponent<IInputProvider>();
        OnStart();
        Initialize();
    }

    protected virtual void OnStart() { }
    protected abstract void Initialize();
}
