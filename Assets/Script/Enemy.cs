using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 怪物的抽象父类
public abstract class Enemy : MonoBehaviour
{
    //定义怪物血量
    public int health;
    //定义怪物伤害值
    public int damage;

    //闪烁时间
    public float flashTime;

    //金币的预制体
    public GameObject dropCoin;
    //显示伤害值
    public GameObject floatPoint;

    // 红色闪烁的原理就是改变物体的 Sprite Renderer 的颜色
    private SpriteRenderer sr;
    //保存原有的颜色
    private Color originalColor;

    // 获取流血特效
    public GameObject bloodEffect;

    // 访问 PlayerHealth 类
    private PlayerHealth playerHealth;
    //获取刚体组件
    private Rigidbody2D enemyRigidbody;

    //获取物体当前的 x 位置
    float curpos;
    // 获取物体下一帧的 x 位置
    float lastpos=0;


    // Start is called before the first frame update
    public void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        sr = GetComponent<SpriteRenderer>();
        //存储初始颜色
        originalColor = sr.color;
    }

    // Update is called once per frame
    public void Update()
    {
        Flip();
        DeathVerdict();
    }

    //死亡判定函数
    public virtual void DeathVerdict()
    {
        if (health <= 0)
        {
            //销毁
            DestroyEnemy();
        }
    }

    public void TakeDamage(int damage)
    {
        SoundManager.AttackEnemy();
        GameObject gb  = Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
        gb.transform.GetChild(0).GetComponent<TextMesh>().text = "-" + damage.ToString();
        health -= damage;
        FlashColor(flashTime);
        Instantiate(bloodEffect,transform.position, Quaternion.identity);
        // 减少生命后调用相机的抖动脚本
        GameController.camShake.Shake();
    }

    //根据时间改变贴图颜色
    void FlashColor(float time)
    {
        sr.color = Color.red;
        // 闪烁事件后调用函数还原颜色
        Invoke("ResetColor", time);
    }

    //还原原来的颜色
    void ResetColor()
    {
        sr.color = originalColor;
    }

    //触发攻击 Player
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            if(playerHealth != null)
            {
                playerHealth.DamagePlayer(damage);
            }
        }
    }

    //反转人物贴图函数
    public void Flip()
    {
        curpos = gameObject.transform.position.x;//当前点
        float _speed = (curpos - lastpos) / Time.deltaTime;//与上一个点做计算除去当前帧花的时间。
        lastpos = curpos;//把当前点保存下一次用
                         //如果速度是正就不反转
        if (_speed >= 0.0f)
         {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        //如果速度是负数就反转
        else
         {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
         }
    }

    //销毁游戏物体
    public void DestroyEnemy()
    {
        Destroy(gameObject);
        //生成金币
        Instantiate(dropCoin, transform.position, Quaternion.identity);
    }
}
