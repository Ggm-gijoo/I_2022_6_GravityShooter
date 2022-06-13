using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float runningSpeed = 10f;
    private float rotateSpeed = 80f;
    private float jumpPower = 5f;

    private Rigidbody playerRigid;
    private CharacterController playerCtrl;
    private Animator playerAnim;
    private CameraController cameraController;

    private void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
        playerCtrl = GetComponent<CharacterController>();
        playerAnim = GetComponent<Animator>();
        cameraController = Camera.main.GetComponent<CameraController>();

        playerAnim.Play("Idle");
    }
    private void Update()
    {
        Move();
        Jump();
    }

    public void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float m = Input.GetAxis("Mouse X");

        if(Input.GetKey(KeyCode.LeftShift))
            transform.Translate((Vector3.forward * v + Vector3.right * h) * Time.deltaTime * runningSpeed);
        else
            transform.Translate((Vector3.forward * v + Vector3.right * h) * Time.deltaTime * moveSpeed);
        transform.Rotate(Vector3.up * m * rotateSpeed * Time.deltaTime);

        transform.forward = cameraController.cameraTransformStaticX.forward;


        playerAnim.SetFloat("Horizontal", h);
        playerAnim.SetFloat("Vertical", v);

    }

    private void OnAnimatorIK(int layerIndex)
    {
        playerAnim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0f);
        playerAnim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0f);

        playerAnim.SetIKPosition(AvatarIKGoal.LeftHand, cameraController.cameraTransform.position);
        playerAnim.SetIKRotation(AvatarIKGoal.LeftHand, cameraController.cameraTransform.rotation);

        playerAnim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
        playerAnim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0f);

        playerAnim.SetIKPosition(AvatarIKGoal.RightHand, cameraController.cameraTransform.position);
        playerAnim.SetIKRotation(AvatarIKGoal.RightHand, cameraController.cameraTransform.rotation);
    }

    public void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            playerAnim.SetTrigger("Jump");
            playerRigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }



}
