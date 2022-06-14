using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("플레이어 트랜스폼")]
    [SerializeField]
    private Transform targetTransform;

    public Transform cameraTransform;
    public Transform cameraTransformStaticX;

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
        rotationY = Mathf.Clamp(rotationY, -30, 30);

        cameraTransform.eulerAngles = new Vector3(-rotationY, rotationX, 0);
        cameraTransform.position = targetTransform.position;
        cameraTransformStaticX.eulerAngles = new Vector3(0, rotationX, 0);
        cameraTransformStaticX.position = targetTransform.position;
    }
}
