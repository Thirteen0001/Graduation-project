using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //定义伤害数值
    private int damage;
    //设置协程开始时间
    public float StartTime;
    //设置协程回调时间
    public float time;

    //攻击冷却时间
    public float attackCooldown;
    //下一次可攻击的时间
    private float nextAttackTime = float.NegativeInfinity;

    //判断是否可以攻击
    public static bool canAttack;


    //获取父对象动画控制
    private Animator anim;
    //获取自身的碰撞体组件
    private PolygonCollider2D collider2D;

    // 切换控制模块
    #region
    private PlayerInputAction controls;

    void Awake()
    {
        // 改变输入映射
        controls = new PlayerInputAction();

        //攻击
        controls.GamePlay.Attack.started += ctx => Attack();
    }

    void OnEnable()
    {
        controls.GamePlay.Enable();
    }

    void OnDisEnable()
    {
        controls.GamePlay.Disable();
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        canAttack = GameController.canAttack;
        //给初始伤害赋值
        damage = GameController.StartDamage;
        //Debug.Log(damage);
    }

    //攻击函数
    void Attack()
    {
        if (canAttack)
        {
            if (Time.time >= nextAttackTime)
            {
                anim.SetTrigger("Attack");
                //攻击声音
                SoundManager.AttackNull();
                //启动协程
                StartCoroutine(startAttack());
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    IEnumerator startAttack()
    {
        yield return new WaitForSeconds(StartTime);
        collider2D.enabled = true;
        StartCoroutine(disableHitBox());
    }

    // 设置协程
    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        collider2D.enabled = false;
    }

    //触发攻击函数
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
