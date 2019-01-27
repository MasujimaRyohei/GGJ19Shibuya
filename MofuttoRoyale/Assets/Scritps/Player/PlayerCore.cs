using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerCore : MonoBehaviour
{
    [SerializeField] private int PointRate;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float Power;
    

    private int _playerID;
    public int PlayerID { get { return _playerID; } }

    private PlayerType _playerType;
    public PlayerType PlayerType { get { return _playerType; } }

    private Vector3 _respownPoint;
    public Vector3 RespownPoint { get { return _respownPoint; } }

    private PlayerInfo _currentPlayerInfomation;
    public PlayerInfo CurrentPlayerInfomation { get => _currentPlayerInfomation; }

    private PlayerInfo _normalPlayerInfomation;
    public PlayerInfo NormalPlayerInfomation { get => _normalPlayerInfomation; }

    private ReactiveProperty<bool> _isInitializedPlayer = new BoolReactiveProperty(false);
    public IReadOnlyReactiveProperty<bool> IsInitializedPlayer { get => _isInitializedPlayer; }

    public ReactiveProperty<bool> IsAttacking = new BoolReactiveProperty(false);

    private PlayerMover _playerMover;
public bool IsMovable
    {
        get { return _playerMover.enabled; }
        set { _playerMover.enabled = value; }
    }
    
    public void InitializePlayer(int id, PlayerType type, Vector3 point)
    {
        _playerID = id;
        _playerType = type;
        _respownPoint = point;

        _playerMover = GetComponent<PlayerMover>();
        SetPlayerInfomation();
        _isInitializedPlayer.Value = true;
    }

    private void SetPlayerInfomation()
    {
        _normalPlayerInfomation = new PlayerInfo(PointRate,MoveSpeed,Power);
        _currentPlayerInfomation = NormalPlayerInfomation;

        _isInitializedPlayer.FirstOrDefault()
            .Subscribe(_ =>
            {
                
            });
    }

    void OnCollisionEnter(Collision col)
    {
        _playerMover.OnCollisionOtherPlayer(col);
        AudioManager.Instance.PlaySE("Tackle001");

    }

    void OnTriggerEnter(Collider col)
    {
        var item = col.gameObject.GetComponent<ItemBase>();
        if(item)
        {
            _currentPlayerInfomation = item.UseItem(CurrentPlayerInfomation);
            Destroy(col.gameObject);
        }
    }
}
