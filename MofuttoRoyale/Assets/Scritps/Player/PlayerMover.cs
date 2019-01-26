using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerMover : BasePlayer
{
    public float moveSpeed = 10;
    public bool isAttacking = false;

    private Rigidbody _rigidbody;

    protected override void Initialize()
    {
        Debug.Log("Initialize,Mover" + PlayerID);
        _rigidbody = GetComponent<Rigidbody>();
        InputProvider.MoveDirection
            .Subscribe(x => 
            {
                var value = x.normalized * CurrentPlayerInfo.MoveSpeed;
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
        _rigidbody.AddForce(moveDirection, ForceMode.VelocityChange);
    }

    private void Attack()
    {
        Debug.Log("Player" + PlayerID + "のAttack!");
        isAttacking = true;
    }
}
