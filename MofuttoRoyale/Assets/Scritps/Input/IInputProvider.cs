using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public interface IInputProvider
{
    IReadOnlyReactiveProperty<bool> AttackButton { get; }
    IReadOnlyReactiveProperty<Vector3> MoveDirection { get; }
}
