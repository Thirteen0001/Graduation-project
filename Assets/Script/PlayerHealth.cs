using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;


public class PlayerHealth : MonoBehaviour
{
    // 设置血量
    private int health;
    //闪烁次数
    public int Blinks;
    // 闪烁时间
    public float time;
    //设置死亡动画播放时间
    public float dieTime;
    //设置地刺受伤后的冷却时间
    public float hitBoxCdTime;
    //重置复活状态时间
    public float resetRespawn;

    //获取 Renderer
    private Renderer myRender;
    //获取动画状态机
    private Animator anim;
    //获取 Player 的  Rigidbody2D 用与消除速度
    private Rigidbody2D myRigidbody;

    // 获取 屏幕闪烁脚本
    private ScreenFlash sf;
    // 获取 player 控制脚本
    //private Player_Controller player_Controller;

    //private GameObject player;

    //获取用与受伤的碰撞体
    private PolygonCollider2D polygonCollider2D;
    private CapsuleCollider2D capsuleCollider2D;

    //保存当前关卡编号
    //public static int sceneIndex;

    void Awake()
    {
        //给最大血量赋值
        //health = GameController.MaxHealth;
        //HealthBar.healthMax = GameController.MaxHealth;
        //HealthBar.healthCurrent = GameController.MaxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {

        //给最大血量赋值
        health = GameController.MaxHealth;
        HealthBar.healthMax = GameController.MaxHealth;
        HealthBar.healthCurrent = GameController.MaxHealth;

        GameController.startPos = transform.position;

        
        //给当前血量赋值
        if (SceneManager.GetActiveScene().buildIndex == 1 && GameController.isLoad == 0)
        {
            GameController.MaxHealth = HealthBar.healthCurrent;
        }
        else
        {
            HealthBar.healthCurrent = GameController.currentHealth;
        }


        sf = GetComponent<ScreenFlash>();
        //player_Controller = GetComponent<Player_Controller>();

        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();

        myRender = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

        polygonCollider2D = GetComponent<PolygonCollider2D>();
        capsuleCollider2D = GetComponent <CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("player 的 实时位置： "+transform.position);

        //如果游戏正常运行就要实时刷新血量
        if (GameController.isGameAlive)
        {
            health = GameController.currentHealth;
            HealthBar.healthMax = GameController.MaxHealth;
        }
    }

    // Player 受伤判定  供外部调用
    public void DamagePlayer(int damage)
    {
        //调用红闪
        sf.FlashScreen();
        

        health -= damage;
        if(health <= 0)
        {
            health = 0;
        }
        //else
        //{
        //    //设置受伤动画
        //    //anim.SetBool("Hurt", true);
        //    //Debug.Log(anim.GetBool("Hurt"));
        //    //player_Controller.enabled = false;
        //    RemoveSpeed();
        //}
        //设置实时血量
        HealthBar.healthCurrent = health;
        //死亡判定
        if (health == 0)
        {

            // 播放死亡音效
            SoundManager.PlayerDead();

            //anim.SetBool("Hurt", false);
            anim.SetTrigger("Die");
            // 禁用碰撞体 避免二次触发
            polygonCollider2D.enabled = false;

            // 死亡后先消除原有的速度
            RemoveSpeed();

            //设置游戏状态
            GameController.isGameAlive = false;
            //禁用操控
            DisablePlayerController();
            //禁用移动
            transform.GetComponent<Player_Controller>().enabled = false;

            //死亡后收到伤害会再次播放死亡动画 通过禁用触发伤害碰撞框
            gameObject.GetComponent <PolygonCollider2D>().enabled = false;

            // 隔一段时间后销毁对象
            Invoke("KillPlayer", dieTime);

            //这里 表示已经死亡，不需要后面的闪烁和启用协程 可以避免地磁的二次触发
            return;
        }

        // 受伤音效  未死亡才播放 死亡播放死亡音效
        SoundManager.PlayerWounded();

        //受伤闪烁
        BlinkPlayer(Blinks, time);
        polygonCollider2D.enabled = false;

        

        //启动协程
        StartCoroutine(ShowPlayerHitBox());
    }

    


    //定时后显示碰撞框
    IEnumerator ShowPlayerHitBox()
    {
        

        yield return new WaitForSeconds(hitBoxCdTime);
        polygonCollider2D.enabled = true;

    }

    //销毁 Player
    void KillPlayer()
    {
        //启用状态机后复活
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        Respawn();

        //Destroy(gameObject);
    }

    // 受伤闪烁函数
    void BlinkPlayer(int numBlinks,float seconds)
    {
        StartCoroutine(DoBlink(numBlinks, seconds));
    }

    //闪烁 协程
    IEnumerator DoBlink(int numBlinks, float seconds)
    {
        for (int i = 0;i < numBlinks*2; i++) 
        { 
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRender.enabled = true;
        //结束受伤动画
        //anim.SetBool("Hurt", false);
        //Debug.Log(anim.GetBool("Hurt"));
        //player_Controller.enabled = true;
    }

    //消除速度 函数
    void RemoveSpeed()
    {
        myRigidbody.velocity = UnityEngine.Vector2.zero;
    }

    //复活函数
    void Respawn()
    {

        //只要复活过一次就视为未保存状态
        GameController.isSave = false;

        anim.SetBool("Respawn", true);
        //Debug.Log("动画状态重置");

        //复活位置
        transform.position = GameController.startPos;


        //复活后的血量
        health = HealthBar.healthMax;
        HealthBar.healthCurrent = health;
        //CoinUI.startCoin = GameController.currentCoin;

        //开启碰撞体
        capsuleCollider2D.enabled = true;
        polygonCollider2D.enabled = true;

        //开启操作
        EnablePlayerController();
        //开启控制脚本
        transform.GetComponent<Player_Controller>().enabled = true;

        //死亡次数加一
        DeadUI.currentDeadQuantity++;

        GameController.isGameAlive = true;

        Invoke("ResetState", resetRespawn);
    }

    void ResetState()
    {
        anim.SetBool("Respawn", false);
    }

    public static void DisablePlayerController()
    {
        //禁用跳跃
        GameController.canJump = false;
        //禁用攻击
        GameController.canAttack = false;

    }

    public static void EnablePlayerController()
    {
        //开启跳跃
        GameController.canJump = true;
        //开启攻击
        GameController.canAttack = true;
    }
}
