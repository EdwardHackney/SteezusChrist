using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 10.0f;
    public float height = 10.0f;
    public float rotateSpeed = 20.0f;

    private float oldMouseX;
    private Vector3 direction = Vector3.back;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        oldMouseX = Input.mousePosition.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float mouseDelta = Input.GetAxis("Mouse X");
        oldMouseX = Input.mousePosition.x;
        direction = Quaternion.AngleAxis(mouseDelta * rotateSpeed * Time.deltaTime, Vector3.up) * direction;
        transform.position = target.position + direction * distance + Vector3.up * height;
        transform.LookAt(target);
    }
}
