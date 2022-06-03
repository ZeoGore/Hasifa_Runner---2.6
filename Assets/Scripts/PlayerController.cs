using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isRunning = false;
    
    private CharacterController cc = null;
    
    private Vector3 direction;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity = -20;
    [SerializeField] private float laneSwitchSpeed;
    private int currentLane = 0; // 0=left | 1=middle | 2=middle
    [SerializeField] private float laneDistance = 2;

    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private SwipeDetector swipeDetector;

    private Animator animator;
    
    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (!isRunning) { return; } // if isRunnig is False the Update method will stop here.

        direction.z = forwardSpeed;
        direction.y += gravity * Time.deltaTime;

        if (cc.isGrounded)
        {
            direction.y = -1;

            if (Input.GetKeyDown(KeyCode.UpArrow) || swipeDetector.swipeUp)
            {
                direction.y = jumpForce;
                animator.SetTrigger("Jump"); // triggering the Jump animation. "Jump" is a Trigger Parameter in the player Animator
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        } 

        if (Input.GetKeyDown(KeyCode.RightArrow) || swipeDetector.swipeRight)
        {
            currentLane = Mathf.Clamp(currentLane+1,-1,1);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) || swipeDetector.swipeLeft)
        {
            currentLane = Mathf.Clamp(currentLane - 1, -1, 1);
        }

        direction.x = (-transform.position.x + currentLane * laneDistance) * laneSwitchSpeed;

        cc.Move(direction * Time.deltaTime);
    }

    public void StartRunning()
    {
        isRunning = true;
        animator.SetTrigger("StartRunning"); // triggering the transition to the Run animation (looping). "StartRunning" is a Trigger Parameter in the player Animator
    }

    public void StopRunning()
    {
        isRunning = false;
        animator.SetTrigger("StopRunning"); // triggering the transition to the Idle animation (t-pose). "StopRunning" is a Trigger Parameter in the player Animator
    }

    // to check collision of Character Controller we need to use OnControllerColliderHit instead of OnCollisionEnter
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Obstacle"))
        {
            gameManager.isGameOver = true;
        }
    }

    // OnTriggerEnter works with a CharacterController
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            gameManager.AddToScore();
        }
    }


}
