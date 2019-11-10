using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    Transform playerarms;
    [SerializeField]
    float mouseSensitivity = 5;

    // Update is called once per frame
    void Update()
    {
        //鼠标锁定
        Cursor.lockState = CursorLockMode.Locked;
        RotateCamera();
    }
    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        Vector3 rotPlayer = player.transform.rotation.eulerAngles;
        Vector3 rot_playerArms = playerarms.transform.rotation.eulerAngles;

        rot_playerArms.x -= mouseY;
        rot_playerArms.z = 0;
        rotPlayer.y += mouseX;

        //万向节死锁
        if(mouseX >= 89)
        {
            rot_playerArms.x = 89;
        }else if(mouseX <= -90)
        {
            rot_playerArms.x = 269;
        }
        playerarms.rotation = Quaternion.Euler(rot_playerArms);
        player.rotation = Quaternion.Euler(rotPlayer);

    }
}
