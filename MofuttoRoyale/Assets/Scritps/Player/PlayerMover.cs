using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerMover : BasePlayer
{
    public float moveSpeed = 5;
    public bool isAttacking = false;

    private Rigidbody _rigidbody;

    public void Set()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        Debug.Log("Initialize,Mover" + PlayerID);
        _rigidbody = GetComponent<Rigidbody>();
        InputProvider.MoveDirection
            .Subscribe(x => 
            {
                var value = x.normalized * moveSpeed;
                Move(value);
            });
        
        InputProvider.AttackButton
            .Where(x => x && !isAttacking)
            .Subscribe(x => 
            {
                Attack();
            });
    }

    private void Move(Vector3 moveDirection)
    {
        Debug.Log("Player" + PlayerID + "移動");
        _rigidbody.AddForce(moveDirection, ForceMode.Acceleration);
    }

    private void Attack()
    {
        Debug.Log("Player" + PlayerID + "のAttack!");
        isAttacking = true;
    }
}
