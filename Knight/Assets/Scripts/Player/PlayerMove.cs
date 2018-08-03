using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Animator animator;
    private CharacterController characterController;
    private CollisionFlags collisionFlags = CollisionFlags.None;

    private float moveSpeed = 5f;
    private bool canMove;
    private bool finished_Movement = true;


    private Vector3 target_Pos = Vector3.zero; // new Vector3(0,0,0)
    private Vector3 player_Move = Vector3.zero;

    private float player_ToPointDistance;

    private float gravity = 9.8f;
    private float height;


	// Use this for initialization
	void Awake () {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void MoveThePlayer() {
        if(Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        }
    }
}

