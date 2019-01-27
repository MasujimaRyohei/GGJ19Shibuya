using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class BasePlayer : MonoBehaviour
{
    [SerializeField]
    protected PlayerCore PlayerCore;
    protected int PlayerID { get { return PlayerCore.PlayerID; } }

    private IInputProvider _inputProvider;
    protected IInputProvider InputProvider { get { return _inputProvider; } }

    public PlayerInfo CurrentPlayerInfo { get => PlayerCore.CurrentPlayerInfomation; }

    void Start()
    {
        _inputProvider = GetComponent<IInputProvider>();

        PlayerCore.IsInitializedPlayer.FirstOrDefault()
            .Subscribe(_ => 
            {
                Initialize();
            });
        
        OnStart();
    }

    protected virtual void OnStart() { }
    protected abstract void Initialize();
}
