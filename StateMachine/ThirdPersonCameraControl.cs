using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraControl : NormalCameraPosition
{

    [SerializeField]
    private Transform _cameraPositionReference;

    private float offsetMagnitude;
    private float thenOffset;
    private bool wallHit;

    protected override void Start()
    {
        base.Start();
        offsetMagnitude = _offset.magnitude;

        wallHit = false;
        thenOffset = _offset.magnitude;
    }

    protected override void Update()
    {
        float turnHorizontal = Input.GetAxis("Mouse X");

        _offset = Quaternion.AngleAxis(turnHorizontal * rotationSpeed, Vector3.up) * _offset;

        if (!stop)
        {
            transform.position = _target.position + _offset;
        }

        base.Update();
    }
}