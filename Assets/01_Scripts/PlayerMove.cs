using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveSpeed = 10f;
    private float rotateSpeed = 80f;
    private float jumpPower = 5f;

    private Rigidbody playerRigid;
    private Animator playerAnim;

    private void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();

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

        transform.Translate((Vector3.forward * v + Vector3.right * h) * Time.deltaTime * moveSpeed);
        transform.Rotate(Vector3.up * m * rotateSpeed * Time.deltaTime);


        playerAnim.SetFloat("Horizontal", h);
        playerAnim.SetFloat("Vertical", v);

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
