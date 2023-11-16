using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    //using this tutorial:https://youtu.be/_QajrabyTJc

    public float mouseSensitivity = 100f;
    private float xRotation = 0.0f;
    private Camera cam;
    public Transform PlayerB;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        if (cam) { Debug.Log("I have the camera"); }

        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        //get inputs from mouse, multiply by mouse sensititvity
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Rotate camera along it's x axis using mouse Y
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //Spin Player Body using Mouse X
        PlayerB.Rotate(Vector3.up * mouseX);

    }

}
