using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    Transform player;

    Vector2 moveDirection;

    private Rigidbody2D rb;
    private PlayerAwarenessController pac;
    private Vector2 _targetDirection;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pac = GetComponent<PlayerAwarenessController>();
    }

    void Start()
    {
        player = GameObject.Find("MainCharacter").transform;
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        if (pac.AwareOfPlayer)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            moveDirection = direction;
        }
        else
        {
            _targetDirection = Vector2.zero;
        }
    }


    private void SetVelocity()
    {
        if (pac.AwareOfPlayer)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * _speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
