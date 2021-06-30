using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Vector3 topLeftMaxPosition, bottomRightMaxPosition;

    void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 targetedPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetedPosition, smoothSpeed);

        if (isInRange(smoothedPosition))
        {
            transform.position = smoothedPosition;
            transform.LookAt(target);
            transform.rotation = Quaternion.identity;
        }
    }

    private bool isInRange(Vector3 _position)
    {
        bool isInRangeXAxis = topLeftMaxPosition.x <= _position.x && bottomRightMaxPosition.x > _position.x;
        bool isInRangeYAxis = topLeftMaxPosition.y > _position.y && bottomRightMaxPosition.y <= _position.y;

        return isInRangeXAxis && isInRangeYAxis;
    }
}
