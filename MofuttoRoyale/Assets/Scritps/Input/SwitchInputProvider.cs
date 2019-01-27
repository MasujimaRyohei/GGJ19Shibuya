using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class SwitchInputProvider : BasePlayer, IInputProvider
{
    private ReactiveProperty<bool> _attack = new ReactiveProperty<bool>();
    private ReactiveProperty<Vector3> _moveDirection = new ReactiveProperty<Vector3>();
    public IReadOnlyReactiveProperty<bool> AttackButton { get { return _attack; } }
    public IReadOnlyReactiveProperty<Vector3> MoveDirection { get { return _moveDirection; } }

    
    public string Horizontal;
    public string Vertical;
    public string Attack;

    protected override void Initialize()
    {
        int id = PlayerID + 1;
        Horizontal = "Horizontal" + id;
        Vertical = "Vertical" + id;
        Attack = "joystick " + id + " button 1";

        this.UpdateAsObservable()
            .Select(x => Input.GetKeyDown(Attack))
            .DistinctUntilChanged()
            .Subscribe(x => _attack.Value = x);

        this.UpdateAsObservable()
            .Select(x => new Vector3(Input.GetAxis(Horizontal), 0, Input.GetAxis(Vertical)))
            .Subscribe(x => 
            {
                _moveDirection.Value = x;
            });
    }
}
