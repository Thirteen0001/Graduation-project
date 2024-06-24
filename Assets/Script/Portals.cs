using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    //传送到的位置
    public Transform backDoor;
    //判断碰到的是不是门
    private bool isDoor;
    //Player 的位置
    private Transform playerTransform;

    // 传送冷却时间
    public float Cooldown;
    //下一次可传送的时间
    private float nextPortals = float.NegativeInfinity;

    // 切换控制模块
    #region
    private PlayerInputAction controls;

    void Awake()
    {
        // 改变输入映射
        controls = new PlayerInputAction();

        //攻击
        controls.GamePlay.EnterDoor.started += ctx => EnterDoor();
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
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnterDoor()
    {
        if(isDoor && Time.time>=nextPortals)
        {
            playerTransform.position = backDoor.position;
            nextPortals = Time.time + Cooldown;

            //播放传送门音效
            SoundManager.Portals();
        }
    }

    // 进入门的范围
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isDoor = true;
        }
    }

    //离开门的范围
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isDoor = false;
        }
    }

}
