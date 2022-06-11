using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("플레이어 트랜스폼")]
    [SerializeField]
    private Transform targetTransform;

    public Transform cameraTransform;

    private float detailX = 5.0f;
    private float rotationX = 0.0f;


    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        rotationX = cameraTransform.eulerAngles.y + mouseX * detailX;
        rotationX = (rotationX > 180.0f) ? rotationX - 360 : rotationX;
        cameraTransform.eulerAngles = new Vector3(0, rotationX, 0);
        cameraTransform.position = targetTransform.position;
    }
}
