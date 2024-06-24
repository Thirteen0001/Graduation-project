using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //平台移动速度
    public float speed;
    //到达点后的停顿时间
    public float waitTime;
    //点
    public Transform[] movePos;

    // 定位两个点的取值
    private int i;
    // 记录等待时间
    private float time;

    //获取 Player 的 刚体组件
    private Transform playerDefaultTransform;
    //获取金币的刚体组件
    private Transform coinDefaultTransform;


    // Start is called before the first frame update
    void Start()
    {
        i = 1;
        time = waitTime;
        //获取 Player 默认的 transform
        playerDefaultTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;
        //coinDefaultTransform = GameObject.FindGameObjectWithTag("Coin").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // 重复往返运动原理  让平台向目标点移动
        transform.position = Vector2.MoveTowards(transform.position, movePos[i].position,speed * Time.deltaTime);
        //如果平台与目标点的距离相近
        if (Vector2.Distance(transform.position, movePos[i].position) < 0.1f)
        {
            // 如果等待时间 小于0 则把目标点切换为初始点
            if (waitTime < 0.0f)
            {
                //反转目标点
                if(i == 0)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }
                // 重设等待时间
                waitTime = time;
            }
            else
            {
                //等待时间未结束 将不断减少等待时间
                waitTime -= Time.deltaTime;
            }

        }
        
    }

    //当 player 碰到平台时
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            //把 Player当成移动平台的子对象 即可同步运动
            other.gameObject.transform.parent = gameObject.transform;
            //Debug.Log("11");
        }
        //if (other.CompareTag("Coin") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        //{
        //    other.gameObject.transform.parent = gameObject.transform;
        //    Debug.Log("变化");
        //}
    }

    //当 Player 离开平台时
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            // 还原 Player 的 刚体
            other.gameObject.transform.parent = playerDefaultTransform;
        }
        if (other.CompareTag("Coin"))
        {
            other.gameObject.transform.parent = coinDefaultTransform;
        }
    }

}
