using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
    public float CurrentZoom = 10;
    public float Pitch = 2f;

    public float ZoomSpeed = 4f;

    public float ZoomMax = 15f;

    public float ZoomMin = 5f;

    public float YawSpeed = 100f;
    private float _currentYaw = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        //Input axis <0,1> smoothing
        CurrentZoom -= Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;
        CurrentZoom = Mathf.Clamp(CurrentZoom, ZoomMin, ZoomMax);

        //Accumulated input
        _currentYaw += Input.GetAxis("Horizontal") * YawSpeed * Time.smoothDeltaTime;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Vector math
        transform.position = Target.position - Offset * CurrentZoom;
        transform.LookAt(Target.position + Vector3.up * Pitch);

        transform.RotateAround(Target.position, Vector3.up, _currentYaw);
    }
}
