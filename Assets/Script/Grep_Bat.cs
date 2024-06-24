using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;

public class Grep_Bat : Enemy
{
    //追击速度
    public float speed;
    //检测半径
    public float radius;

    // 销毁时间
    public float destoryTime;
    //获取动画控制器
    private Animator anim;
    //存储 player 的组件
    private Transform playerTransform;
    // 获取碰撞体
    private BoxCollider2D boxCollider;

    //控制是否追击
    private bool isPursuit;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        //开启追击
        isPursuit = true;
    }

    // Update is called once per frame
    void Update()
    {
        //调用父类的 Updata 方法
        base.Update();
        Pursuit();
    }

    void Pursuit()
    {
        if (playerTransform != null && isPursuit)
        {
            //判断 player 和 bat 的距离
            float distance = (transform.position - playerTransform.position).sqrMagnitude;
            if (distance < radius)
            {
                //如果小于检测半径就让 bat 往 player 移动
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            }
        }
    }

    public override void DeathVerdict()
    {
        if (health <= 0)
        {
            //关闭碰撞体
            boxCollider.enabled = false;
            // 取消追击
            isPursuit = false;
            //销毁动画
            anim.SetBool("Destory", true);
            //销毁
            Invoke("DestroyEnemy", destoryTime);
        }
    }
}
