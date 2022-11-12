using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationMobile : MonoBehaviour
{

    //Personaje
    
    Transform tr;

    //Camara

    public Transform cameraShoulder;
    public Transform cameraHolder;
    private Transform cam;

    private float rotY = 0f;

    public float rotationSpeed = 200;
    public float minAngle = -45;
    public float maxAngle = 45;
    public float cameraSpeed = 200;

    //[SerializeField]private bl_Joystick Joystick;


    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        tr = this.transform;

        cam = Camera.main.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        CameraControl();

    }

    public void CameraControl()
    {
        float mouseX = SimpleInput.GetAxis("Mouse X");
        float mouseY = SimpleInput.GetAxis("Mouse Y");
        float deltaT = Time.deltaTime;

        rotY += mouseY * rotationSpeed * deltaT;

        float rotX = mouseX * rotationSpeed * deltaT;

        tr.Rotate(0, rotX, 0);

        rotY = Mathf.Clamp(rotY, minAngle, maxAngle);

        Quaternion localRotation = Quaternion.Euler(-rotY, 0, 0);
        cameraShoulder.localRotation = localRotation;

        cam.position = Vector3.Lerp(cam.position, cameraHolder.position, cameraSpeed * deltaT);
        cam.rotation = Quaternion.Lerp(cam.rotation, cameraHolder.rotation, cameraSpeed * deltaT);

    }
}
