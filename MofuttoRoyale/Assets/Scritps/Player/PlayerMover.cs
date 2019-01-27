using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerMover : BasePlayer
{
    public float moveSpeed = 10;
    private Rigidbody _rigidbody;

    protected override void Initialize()
    {
        _rigidbody = GetComponent<Rigidbody>();
        InputProvider.MoveDirection
            .Subscribe(x =>
            {
                var value = x.normalized * CurrentPlayerInfo.MoveSpeed;
                Move(value);
                if (value.magnitude > 0.01) LookAtForward(value);
            });

        InputProvider.AttackButton
            .Where(x => x && !PlayerCore.IsAttacking.Value)
            .Subscribe(x =>
            {
                StartCoroutine(Attack());
            });
    }

    private void Move(Vector3 moveDirection)
    {
        _rigidbody.AddForce(moveDirection, ForceMode.Impulse);
    }
    private void LookAtForward(Vector3 targetDirection)
    {
        var lookRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation,lookRotation,Time.deltaTime * 25.0f);
    }

    private IEnumerator Attack()
    {
        Debug.Log("Player" + PlayerID + "のAttack!");
        PlayerCore.IsAttacking.Value = true;
        yield return new WaitForSeconds(0.5f);
        PlayerCore.IsAttacking.Value = false;
    }

    void OnCollisionEnter(Collision col)
    {
        var isPlayer = col.gameObject.GetComponent<PlayerCore>();
        if (isPlayer == null) return;
        if (PlayerCore.IsAttacking.Value)
        {
            col.gameObject.GetComponent<PlayerMover>().AttackedByPlayer(transform.position, CurrentPlayerInfo.Power);
        }
        else
        {
            var value = (transform.position - col.gameObject.transform.position).normalized * CurrentPlayerInfo.Power * 0.7f;
            _rigidbody.AddForce(value, ForceMode.Impulse);
        }
    }

    public void AttackedByPlayer(Vector3 attackerPos, float power)
    {
        var value = (transform.position - attackerPos).normalized * power;
        _rigidbody.AddForce(value, ForceMode.Impulse);
    }
}
