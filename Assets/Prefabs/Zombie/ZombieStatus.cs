using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Common:MonoBehaviour
{
    public static float zombienumber = 10;
}
public class ZombieStatus : MonoBehaviour
{
    /// <summary>
    /// 当前血量
    /// </summary>
    public float currentHP = 100;
    /// <summary>
    /// 最大血量
    /// </summary>
    public float maxHP = 100;

    /// <summary>
    /// 死亡僵尸数量
    /// </summary>
    //public Common common;
    float zombienumber = Common.zombienumber;


    public float ZombieNumber = 0;


    public Animator anim;

    private void Update()
    {

        NextLevel();
        //if (ZombieNumber >= 5)
        //{
         //   SceneManager.LoadScene("End");
        //    Debug.Log("玩家击杀僵尸超过5个，进入下一关");
        //}
    }
    public void Damage(float amount)
    {
        //如果敌人已经死亡 则退出(防止虐尸)
        //if (currentHP <= 0) return;
        anim = this.GetComponent<Animator>();
        anim.SetBool("hit", true);
        currentHP -= amount;
        Invoke("SetFalse", 0.3f);

        if (currentHP <= 0)
        {
            ZombieNumber += 1;
            zombienumber -= 1;
            Debug.Log("目前为止击杀丧尸数量为：" + ZombieNumber+"还需击杀数量为："+zombienumber);
            Death();
        }
    }

    //击杀僵尸到10个时，跳转到下一关场景
    public void NextLevel() {
        if (ZombieNumber >= 5 || zombienumber <=5)
        {
            SceneManager.LoadScene("End");  //跳转到名字为 End 的场景
            Debug.Log("玩家击杀僵尸超过5个，进入下一关");
        }
        
    }

    void SetFalse()
    {
        anim.SetBool("hit", false);
    }
    /// <summary>
    /// 死亡延迟时间
    /// </summary>
    public float deathDelay = 2;

    //敌人生成器引用  敌人创建时由生成器传递
    public ZombieSpawn spawn;
    /// <summary>
    /// 死亡
    /// </summary>
    public void Death()
    {
        //ZombieNumber += 1;
        //Debug.Log("目前为止击杀丧尸数量为：" + ZombieNumber);
        //销毁当前游戏物体
        Destroy(gameObject, deathDelay);

        //播放动画
        var anim = GetComponent<Animator>();
        anim.SetTrigger("death");

        //修改状态
        GetComponent<ZombieAI>().state = ZombieAI.State.Death;

        //修改路线状态
        GetComponent<ZombieControl>().wayline.IsUsable = true;

        //需要再生成一个敌人
        spawn.GenerateZombie();
  //      spawn.GenerateZombie();
        spawn.GenerateZombie();
    }
}
