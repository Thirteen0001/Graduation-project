using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySpike : MonoBehaviour
{ 

    //定义伤害
    public int damage;
    //终点坐标
    //public Transform endPosition;

    //速度
    public float flySpeed;

    //定义还原时间
    public float resetTime;

    //记录原位置
    private Vector3 startPos;


    //获取Player生命值
    private PlayerHealth playerHealth;
    private Rigidbody2D rigidbody2D;


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        //初始化开始坐标
        startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 定义射线
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
        
        if (hit.collider != null)
        {
            //如果碰到了东西
            //Debug.Log("有物体经过");
            //Debug.Log(hit.collider);
            if (hit.collider.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
            {
                Debug.Log("找到了");
                Fly();
            }

        }
    }

    public void Fly()
    {
        //直接给速度飞行
        rigidbody2D.velocity = new Vector3(0f, flySpeed, 0f);
        //transform.position = Vector3.MoveTowards(transform.position, endPosition.position, flySpeed * Time.deltaTime);
        Invoke("ResetSelf", resetTime);
    }

    public void ResetSelf()
    {
        //消除速度还原位置
        rigidbody2D.velocity = new Vector3(0f, 0f, 0f);
        transform.position = startPos;
    }

    //Player 碰到受伤
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            playerHealth.DamagePlayer(damage);
        }
    }
}
