using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerAnimationController : BasePlayer
{
    private Animator _animator;

    protected override void Initialize()
    {
        _animator = GetComponent<Animator>();
        PlayerCore.IsAttacking
            .Select(x => x)
            .Subscribe(x => _animator.SetBool("IsAttacking", x));
    }
}
