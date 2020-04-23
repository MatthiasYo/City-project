using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float minScrollY = 5;
    float maxScrollY = 30;

    public float scrollSensitivity = 10f;

    float currentY;
    float currentX;
    float currentZ;

    public float dragSpeed = 2;
    private Vector3 dragOrigin;

    void Update()
    {
        currentY = transform.position.y;
        currentX = transform.position.x;
        currentZ = transform.position.z;

        // Scroll Input
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(currentY > minScrollY)
            {
                transform.position = transform.position + new Vector3(0, -scrollSensitivity * Time.deltaTime, 0);
                //transform.Translate(new Vector3(0, -scrollSensitivity * Time.deltaTime, 0));
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (currentY < maxScrollY)
            {
                transform.position = transform.position + new Vector3(0, scrollSensitivity * Time.deltaTime, 0);
            }
        }

        // Check its not too far
        if(currentY < minScrollY)
        {
            transform.position = new Vector3(currentX, minScrollY, currentZ);
        }
        else if (currentY > maxScrollY)
        {
            transform.position = new Vector3(currentX, maxScrollY, currentZ);
        }

        // Camera Rotation
        if (currentY < 10)
        {
            transform.rotation = Quaternion.Euler(10, 0, 0);
        }
        else if (currentY < 15)
        {
            transform.rotation = Quaternion.Euler(20, 0, 0);
        }
        else if (currentY < 20)
        {
            transform.rotation = Quaternion.Euler(30, 0, 0);
        }
        else if (currentY < 25)
        {
            transform.rotation = Quaternion.Euler(40, 0, 0);
        }
        else if (currentY < 30)
        {
            transform.rotation = Quaternion.Euler(50, 0, 0);
        }

        // Move Camera
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * -dragSpeed, 0, pos.y * -dragSpeed);

        transform.Translate(move, Space.World);
    }
}
