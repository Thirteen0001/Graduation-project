using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatform : MonoBehaviour
{
    public float resetTime;

    //获取自身的动画状态机和碰撞体
    private Animator anim;
    private BoxCollider2D box2D;

    //标记平台是否已经坍塌
    private bool isCollapsed;

    //重新出现的时间
    //public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        //初始化未坍塌
        isCollapsed = false;
        anim = GetComponent<Animator>();
        box2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D" && !isCollapsed)
        {
            anim.SetTrigger("Collapse");
        }
    }

    //重置游戏物体
    void DestroyTrapPlatform()
    {
        //Destroy(gameObject);
        Invoke("ResetTrapPlatform", resetTime);
    }

    //还原平台
    void ResetTrapPlatform()
    {
        //播放复原动画
        anim.SetBool("Reset",true);
        anim.ResetTrigger("Collapse");
    }


    //禁用碰撞体
    void DisableBoxCollider2D()
    {
        box2D.enabled = false;
    }

    void EnabledBoxCollider2D()
    {
        box2D.enabled = true;
        anim.SetBool("Reset", false);

    }

}
