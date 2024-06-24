using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Green_Ghost : Enemy
{
    //移动速度
    public float speed;
    //到达目标位置后的等待时间
    public float waitTime;
    //爬行位置信息
    public Transform[] movePos;
    // 销毁时间
    public float destoryTime;

    //数组下标
    private int i = 0;
    //爬行方向 默认向右
    private bool movingRight = true;
    //记录等待时间
    private float wait;
    // 获取碰撞体
    private BoxCollider2D boxCollider;
    //获取碰撞体
    private Animator anim;
    // 判断是否移动
    private bool isMove;




    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        isMove = true;
        wait = waitTime;
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
        Move();
    }

    //移动函数
    void Move()
    {
        if(isMove)
        {
            //向目标点移动
            transform.position = Vector2.MoveTowards(transform.position, movePos[i].position, speed * Time.deltaTime);

            //距离接近的时候
            if (Vector2.Distance(transform.position, movePos[i].position) < 0.1f)
            {
                if (waitTime > 0)
                {
                    waitTime -= Time.deltaTime;
                }
                else
                {
                    //控制贴图转向
                    if (movingRight)
                    {
                        transform.eulerAngles = new Vector3(0, -180, 0);
                        movingRight = false;
                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        movingRight = true;
                    }
                    //切换移动点
                    if (i == 0)
                    {
                        i = 1;
                    }
                    else
                    {
                        i = 0;
                    }
                    //恢复cd时间
                    waitTime = wait;
                }
            }
        }
        
    }

    public override void DeathVerdict()
    {
        if (health <= 0)
        {
            boxCollider.enabled = false;
            //取消移动
            isMove = false;

            //销毁动画
            anim.SetBool("Destroy", true);
            //销毁
            Invoke("DestroyEnemy", destoryTime);
        }
    }
}
