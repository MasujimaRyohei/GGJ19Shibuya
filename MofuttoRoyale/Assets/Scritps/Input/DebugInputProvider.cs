using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class DebugInputProvider : BasePlayer, IInputProvider
{
    private ReactiveProperty<bool> _attack = new ReactiveProperty<bool>();
    private ReactiveProperty<Vector3> _moveDirection = new ReactiveProperty<Vector3>();
    public IReadOnlyReactiveProperty<bool> AttackButton { get { return _attack; } }
    public IReadOnlyReactiveProperty<Vector3> MoveDirection { get { return _moveDirection; } }

    private string Horizontal = "Horizontal0";
    private string Vertical = "Vertical0";
    private KeyCode KeyCode = KeyCode.Space;

    protected override void Initialize()
    {
        this.UpdateAsObservable()
            .Select(x => Input.GetKeyDown(KeyCode))
            .DistinctUntilChanged()
            .Subscribe(x => _attack.Value = x);
        
        this.UpdateAsObservable()
            .Select(x => new Vector3(Input.GetAxis(Horizontal),0,Input.GetAxis(Vertical)))
            .Subscribe(x => _moveDirection.Value = x);
    }
}
