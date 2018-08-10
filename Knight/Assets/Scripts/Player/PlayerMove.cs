using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Animator animator;
    private CharacterController characterController;
    private CollisionFlags collisionFlags = CollisionFlags.None;

    private float moveSpeed = 5f;
    private bool canMove;
    private bool finished_Movement;


    private Vector3 target_Pos = Vector3.zero; // new Vector3(0,0,0)
    private Vector3 player_Move = Vector3.zero;

    private float player_ToPointDistance;

    [SerializeField]
    private float gravity = 9.8f;
    [SerializeField]
    private float height;


	// Use this for initialization
	void Awake () {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        CalculateHeight();
        CheckIfFinishedMovement();
	}

    // determines that the player character is on ground
    bool IsOnGround (){
        return collisionFlags == CollisionFlags.CollidedBelow ? true : false;

    }

    // determines gravity for player character
    void CalculateHeight (){
        if (IsOnGround()){
            height = 0f;
        } else {
            height -= gravity * Time.deltaTime;
        }
    }


    void CheckIfFinishedMovement (){
        if (!finished_Movement) {
            if(!animator.IsInTransition(0) 
               && !animator.GetCurrentAnimatorStateInfo(0).IsName("Stand")
               && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f){
                // normalized time for anim is 0 - 1 (1 == already or about to be finished)
                finished_Movement = true;
            } else {
                MoveThePlayer();
                player_Move.y = height * Time.deltaTime;
                collisionFlags = characterController.Move(player_Move);
            }
        }
    }

    void MoveThePlayer() {
        if(Input.GetMouseButtonDown(0)) {

            Debug.Log(Input.mousePosition);

            // get the position in realworld which has been clicked on screen
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)) {
                if(hit.collider is TerrainCollider){

                    //distance from the character to the point of the mouse clikced
                    player_ToPointDistance = Vector3.Distance(transform.position, hit.point);

                    if(player_ToPointDistance >= 1.0f) {
                        canMove = true;
                        target_Pos = hit.point;
                    }
                }
            }
        } // if mouse button down

        if (canMove) {
            animator.SetFloat("Walk", 1.0f);

            // target set
            Vector3 target_Temp = new Vector3(target_Pos.x, transform.position.y, target_Pos.z);


            // rotating
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(target_Temp - transform.position),
                                                  15.0f * Time.deltaTime);

            // actual moving
            player_Move = transform.forward * moveSpeed * Time.deltaTime;


            // if dist is too short, than flag false(stop)
            if (Vector3.Distance(transform.position, target_Pos) <= 0.5f)
            {
                canMove = false;
            }
        }  else { // when can't move
          //set vector to 0, walk anim to 0
            player_Move.Set(0f, 0f, 0f);
            animator.SetFloat("Walk", 0f);
        }
    }

}

