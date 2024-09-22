using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    private Rigidbody2D myRigidBody;
    private Vector3 myPositionChange;
    private Animator animator;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        myPositionChange = Vector2.zero;
        myPositionChange.x = Input.GetAxisRaw("Horizontal");
        myPositionChange.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove() {
        if (myPositionChange != Vector3.zero) {
            MoveCharacter();
            animator.SetFloat("moveX", myPositionChange.x);
            animator.SetFloat("moveY", myPositionChange.y);
            animator.SetBool("moving", true);
        } else {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter() {
        myRigidBody.MovePosition(
            transform.position + myPositionChange * speed * Time.deltaTime
            ) ;
    }
}
