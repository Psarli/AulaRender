using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform followingTarget;
    
    [SerializeField] float rotationSpeed = 2.0f;
    [SerializeField] float distance = 5.0f;

    [SerializeField] float minVerticalAngle = -20.0f;
    [SerializeField] float maxVerticalAngle = 45.0f;

    [SerializeField] Vector2 framingoOffset;


    [SerializeField] bool invertX;
    [SerializeField] bool invertY;


    float rotationX;
    float rotationY;

    float invertXValue;
    float invertYValue;



    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        //condi��o de invers�o de camera
        invertXValue = (invertX) ? -1 : 1; // Tipo if: if = condi��o ? "true : false"
        invertYValue = (invertY) ? -1 : 1;

        //INPUTS
        //rota��o da camera em X relativo ao Y do mouse
        rotationX += Input.GetAxis("Mouse Y") * invertYValue * rotationSpeed;

        rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);//restri��o de rpta��o de camera

        rotationY += Input.GetAxis("Mouse X") * invertXValue * rotationSpeed;
        
        var targetRotation = Quaternion.Euler(rotationX, rotationY, 0.0f);

        var focusPosition = followingTarget.position + (Vector3)framingoOffset;

        transform.position = focusPosition - targetRotation * new Vector3(0.0f, 0.0f, distance);
        transform.rotation = targetRotation;


    }
}
