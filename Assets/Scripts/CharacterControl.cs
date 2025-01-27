using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public Animator BullAnimator;
    public float rotationSpeed = 100f;

    private Animator animator;
    private Rigidbody rb;

    public float moveSpeed = 5f;
    public float smoothSpeed = 2f;
    public float targetValue = 0f;
    public float WalkingSpeed;
    public static bool IsMoving;
    public bool IsMovingVerticle;
    public bool IsMovingHorizontal;
    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (UIManager.Instance.InfoPanel.activeSelf)
        {
            return;
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                targetValue = Mathf.MoveTowards(targetValue, 2, smoothSpeed * Time.deltaTime);
            }
            else
            {
                targetValue = Mathf.MoveTowards(targetValue, WalkingSpeed, smoothSpeed * Time.deltaTime);
            }
            IsMoving = true;
            IsMovingVerticle = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            targetValue = Mathf.MoveTowards(targetValue, -1, smoothSpeed * Time.deltaTime);

            IsMoving = true;
            IsMovingVerticle = true;
        }
        else
        {
            if (IsMovingHorizontal == false)
                targetValue = Mathf.MoveTowards(targetValue, 0, smoothSpeed * Time.deltaTime);
            IsMovingVerticle = false;
        }



        if (Input.GetKey(KeyCode.A))
        {
            IsMovingHorizontal = true;
            if (IsMovingVerticle == false && IsMovingHorizontal == true)
            {
                targetValue = Mathf.MoveTowards(targetValue, 1, smoothSpeed * Time.deltaTime);
            }
            // Calculate the target rotation based on the input
            float targetRotation = -1 * rotationSpeed * Time.deltaTime;

            // Smoothly rotate the player
            transform.Rotate(Vector3.up, targetRotation);
            IsMoving = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            IsMovingHorizontal = true;
            if (IsMovingVerticle == false && IsMovingHorizontal == true)
            {
                targetValue = Mathf.MoveTowards(targetValue, 1, smoothSpeed * Time.deltaTime);
            }
            // Calculate the target rotation based on the input
            float targetRotation = 1 * rotationSpeed * Time.deltaTime;

            // Smoothly rotate the player
            transform.Rotate(Vector3.up, targetRotation);
            IsMoving = true;
        }
        else

        {
            IsMovingHorizontal = false;
        }
        //else
        //{
        //    IsMoving = false;
        //    // Smoothly decrease the target value to 0

        //    targetValue = Mathf.MoveTowards(targetValue, 0f, smoothSpeed * Time.deltaTime);
        //}

        animator.SetFloat("Speed", targetValue);
        float moveAmount = targetValue * Time.deltaTime;
        transform.Translate(Vector3.forward * moveAmount * 2);

        //if (ControlFreak2.CF2Input.GetButtonDown("Jump"))
        //{
        //    animator.SetTrigger("Attack");
        //}
    }


}
