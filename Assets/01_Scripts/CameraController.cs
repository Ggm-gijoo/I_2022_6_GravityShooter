using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("�÷��̾� Ʈ������")]
    [SerializeField]
    private Transform targetTransform;

    public Transform cameraTransform;

    private float detailX = 5.0f;
    private float detailY = 5.0f;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;


    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        rotationX = cameraTransform.eulerAngles.y + mouseX * detailX;
        rotationX = (rotationX > 180.0f) ? rotationX - 360 : rotationX;
        rotationY = rotationY + mouseY * detailY;
        rotationY = Mathf.Clamp(rotationY, -45, 80);
        cameraTransform.eulerAngles = new Vector3(-rotationY, rotationX, 0);
        cameraTransform.position = targetTransform.position;
    }
}