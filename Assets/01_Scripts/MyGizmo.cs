using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmo : MonoBehaviour
{
    public Color _color = Color.yellow;
    [Space]
    private float _radius = 3f;

    private void OnDrawGizmos()
    {
        // 기즈모 색상 설정
        Gizmos.color = _color;

        // 생성위치와 반지름 설정
        Gizmos.DrawSphere(transform.position, _radius);
    }
}
