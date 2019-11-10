using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }


    public float HP = 100;
    public float maxHP = 100;

    //玩家头部位置
    public Transform headTF;

    private void Update()
    {
        if (HP <= 0)
        {
            SceneManager.LoadScene("playerdeath");
            //Application.Quit();
        }
    }

    public void Damage(float amount)
    {
        HP -= amount;
        Debug.Log("玩家受伤");
        if(HP <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        print("玩家死亡");
        Debug.Log("玩家已经死亡，退出游戏");
        //Application.Quit();//玩家死亡，游戏结束，退出
        SceneManager.LoadScene("playerdeath");
    }
}
