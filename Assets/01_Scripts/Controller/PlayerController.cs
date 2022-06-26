using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float rotateSpeed = 80f;
    private float jumpPower = 7f;
    private float initHp = 100f;
    private bool isCanJump = true;
    public float InitHp { get {return initHp; } set {initHp = value; } }
    public float CurrHp;



    private Rigidbody playerRigid;
    private Animator playerAnim;
    private CameraController cameraController;
    private BgmManager bgmManager;

    private void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        cameraController = Camera.main.GetComponent<CameraController>();

        bgmManager = GameObject.FindWithTag("BgmManager").GetComponent<BgmManager>();

        CurrHp = initHp;

        playerAnim.Play("Idle");
    }
    private void Update()
    {
        if (Time.timeScale != 0)
        {
            Move();
            Jump();
            CheckEnemy();
        }
    }

    public void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float m = Input.GetAxis("Mouse X");


        transform.Translate((Vector3.forward * v + Vector3.right * h) * Time.deltaTime * moveSpeed);
        transform.Rotate(Vector3.up * m * rotateSpeed * Time.deltaTime);

        transform.forward = cameraController.cameraTransformStaticX.forward;


        playerAnim.SetFloat("Horizontal", h);
        playerAnim.SetFloat("Vertical", v);

    }

    private void OnAnimatorIK(int layerIndex)
    {
        playerAnim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.4f);
        playerAnim.SetIKRotation(AvatarIKGoal.LeftHand, cameraController.cameraTransform.rotation);

        playerAnim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.4f);
        playerAnim.SetIKRotation(AvatarIKGoal.RightHand, cameraController.cameraTransform.rotation);
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && isCanJump)
        {
            playerAnim.SetTrigger("Jump");
            isCanJump = false;
            playerRigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    public void CheckEnemy()
    {
        int enemyCount = 0;
        Collider[] colls = Physics.OverlapSphere(transform.position, 10f);

        foreach(var coll in colls)
        {
            if(coll.CompareTag("Enemy"))
            {
                enemyCount++;
            }
        }
        if (enemyCount > 0)
            bgmManager.state = BgmManager.State.Warning;
        else
            bgmManager.state = BgmManager.State.Basic;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            isCanJump = true;
        }
    }

}
