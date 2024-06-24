using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat : Enemy
{
    //移动速度
    public float speed;
    //到达位置后的等待时间
    public float startWaitTime;
    //等待时间
    private float waitTime;
    //获取刚体
    private Rigidbody2D enemyRigidbody;
    // 获取碰撞体
    private BoxCollider2D boxCollider;

    
    // 销毁时间
    public float destoryTime;
    private Animator anim;

    //下一次要移动到的位置
    public Transform movePos;
    //范围的左下角
    public Transform leftDownPos;
    //范围的右上角
    public Transform rightUpPos;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    public void Update()
    {
       base.Update();

        Move();
    }

    // 移动函数
    void Move()
    {
        // 移动
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    //获取随机位置
    Vector2 GetRandomPos()
    {
        Vector2 radPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x), Random.Range(leftDownPos.position.y,rightUpPos.position.y));
        return radPos;
    }

    public override void DeathVerdict()
    {
        if (health <= 0)
        {
            boxCollider.enabled = false;
            //无限等待 代替消除速度
            movePos.position = enemyRigidbody.transform.position;
            waitTime = 100f;
            
            //销毁动画
            anim.SetBool("Destory", true);
            //销毁
            Invoke("DestroyEnemy", destoryTime);
        }
    }


}
