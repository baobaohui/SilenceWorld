using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraRoation : MonoBehaviour
{
    public float rotateSpeed = 10;
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        if(x!=0||y != 0)
        {
            RotateView(x, y);
        }
    }
    public void RotateView(float x, float y)
    {
        x *= rotateSpeed * Time.deltaTime;
        y *= rotateSpeed * Time.deltaTime;
        this.transform.Rotate(-y, 0, 0);     //上下移动
        this.transform.Rotate(0, x, 0, Space.World);        //左右
    }
}
