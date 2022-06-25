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
        // ����� ���� ����
        Gizmos.color = _color;

        // ������ġ�� ������ ����
        Gizmos.DrawSphere(transform.position, _radius);
    }
}
