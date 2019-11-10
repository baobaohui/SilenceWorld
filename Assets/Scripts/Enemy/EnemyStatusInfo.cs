using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// 敌人状态信息类
/// </summary>
public class EnemyStatusInfo : MonoBehaviour
{
    /// <summary>
    /// 当前血量
    /// </summary>
    public float currentHP;
    /// <summary>
    /// 最大血量
    /// </summary>
    public float maxHP;
    /// <summary>
    /// 死亡僵尸数量
    /// </summary>
    //public float ZombieNumber = 0;

    public void Damage(float amount)
    {
        //如果敌人已经死亡 则退出(防止虐尸)
        if (currentHP <= 0)
        {
            //ZombieNumber += 1;
            return;
        }
        currentHP -= amount;

        if (currentHP <= 0)
        {
           // ZombieNumber += 1;
            Death();
        }
    }

    //击杀僵尸到20个时，跳转到下一关场景
   // public void NextLevel()
   // {
    //    if (ZombieNumber >= 20)
    //    {
    //       SceneManager.LoadScene("End");  //跳转到名字为 End 的场景
   //    }
   //}


    /// <summary>
    /// 死亡延迟时间
    /// </summary>
    public float deathDelay =5;

    //敌人生成器引用  敌人创建时由生成器传递
    public EnemySpawn spawn;
    /// <summary>
    /// 死亡
    /// </summary>
    public void Death()
    {
        //销毁当前游戏物体
        Destroy(gameObject, deathDelay);

        //播放动画
        var anim = GetComponent<EnemyAnimation>();
        anim.Play(anim.deathName);

        //修改状态
        GetComponent<EnemyAI>().state = EnemyAI.State.Death;

        //修改路线状态
        GetComponent<EnemyMotor>().wayline.IsUsable = true;

        //需要再生成一个敌人
        spawn.GenerateEnemy(); 
    }
}
