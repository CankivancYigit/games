using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    Rigidbody2D enemyRigidBody;
    Animator enemyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();  
    }

    void Move()
    { 

        if (isFacingRight())
        {
            enemyRigidBody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            enemyRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    bool isFacingRight()
    {
        return transform.localScale.x > 0f;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        transform.localScale = new Vector2(-(Mathf.Sign(enemyRigidBody.velocity.x)), 1f);    
    }
}
