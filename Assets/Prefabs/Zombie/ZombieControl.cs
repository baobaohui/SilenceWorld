using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieControl : MonoBehaviour
{
    //生成敌人时传递路线引用
    public WayLine1 wayline;
    /// <summary>
    /// 移动速度
    /// </summary>
    public float moveSpeed = 5;

    /// <summary>
    /// 向前移动
    /// </summary>
    public void MovementForward()
    {
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 朝向目标点的旋转
    /// </summary>
    /// <param name="targetPos">目标位置</param> 
    public void LookRotation(Vector3 targetPos)
    {
        //一帧旋转至目标方位
        transform.LookAt(targetPos);
    }

    private int currentIndex;
    /// <summary>
    /// 寻路
    /// </summary>
    public bool Pathfinding()
    {
        //如果索引超过最大值  则 返回false ，表示寻路结束
        if (wayline ==null || currentIndex >= wayline.Points.Length) return false;
        //朝向目标并移动
        LookRotation(wayline.Points[currentIndex]);
        MovementForward();

        //如果到达目标点
        if (Vector3.Distance(transform.position, wayline.Points[currentIndex]) <= 0.2f)
        {
            currentIndex++;
            currentIndex %= wayline.Points.Length-1;
        }

        return true;//返回true 表示 可以继续寻路
    }
}
