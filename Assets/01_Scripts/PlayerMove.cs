using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody playerRigid;
    private float movevSpeed = 10f;

    private void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
    }
    private void Update()
    {
    }

    public void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        playerRigid.velocity = (h * Vector3.right + v * Vector3.forward) * movevSpeed;
    }


}
