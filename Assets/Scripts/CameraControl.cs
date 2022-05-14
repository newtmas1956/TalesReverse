using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Vector2 sensitivity = new Vector2(5, 5);
    [SerializeField]
    private Vector2 interpolation = new Vector2(10, 10);
    [SerializeField]
    private float minCameraClamp = -90f;
    [SerializeField]
    private float maxCameraClamp = 90f;

    private Vector2 input;
    private Vector2 desiredRotation;
    private Quaternion xQuatRotation;
    private Quaternion yQuatRotation;
    private Quaternion xQuatSmoothRotation;
    private Quaternion yQuatSmoothRotation;

    private void ReadInput()
    {
        input.x = Input.GetAxis("Mouse X");
        input.y = Input.GetAxis("Mouse Y");
    }

    private void CalculateRotation()
    {
        desiredRotation.x += input.x * sensitivity.x;
        desiredRotation.y += input.y * sensitivity.y;
        ClampVerticalAngle();
    }

    private void ClampVerticalAngle()
    {
        desiredRotation.y = Mathf.Clamp(desiredRotation.y, minCameraClamp, maxCameraClamp);
    }

    private void CalculateQuaternion()
    {
        xQuatRotation = Quaternion.AngleAxis(desiredRotation.x, Vector3.up);
        yQuatRotation = Quaternion.AngleAxis(desiredRotation.y, -Vector3.right);
    }

    private void LerpQuaternion()
    {
        xQuatSmoothRotation = Quaternion.Slerp(xQuatSmoothRotation, xQuatRotation, interpolation.x * Time.deltaTime);
        yQuatSmoothRotation = Quaternion.Slerp(yQuatSmoothRotation, yQuatRotation, interpolation.y * Time.deltaTime);
    }

    private void ApplyRotation()
    {
        transform.localRotation = yQuatSmoothRotation;
        player.rotation = xQuatSmoothRotation;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        CalculateRotation();
        CalculateQuaternion();
        LerpQuaternion();
        ApplyRotation();
    }

    public Vector2 GetSensetivity()
    {
        return sensitivity;
    }

    public void SetSensetivity(Vector2 sensetivity)
    {
        this.sensitivity = sensetivity;
    }
}
