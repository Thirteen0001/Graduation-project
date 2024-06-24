using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    // 宝箱掉落的东西
    public GameObject coin;
    // 生成金币延迟时间
    public float delayTime;

    //判断是否有钥匙
    public static bool isKey = false;
    //public static int keyIndex = 0;

    // 判断是否能打开
    private bool canOpen;
    //判断是否打开了
    private bool isOpened;
    //动画控制器
    private Animator anim;

    // 切换控制模块
    #region
    private PlayerInputAction controls;

    void Awake()
    {
        // 改变输入映射
        controls = new PlayerInputAction();

        //攻击
        controls.GamePlay.OpenBox.started += ctx => OpenBox();
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
        anim = GetComponent<Animator>();
        isOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        //OpenBox();
    }

    void OpenBox()
    {
        //按下 Q 键打开宝箱逻辑
        //if (Input.GetKeyDown(KeyCode.Q))
        {
            //if (canOpen && !isOpened &&( isKey || keyIndex != 0))
                if (canOpen && !isOpened && isKey)

                {
                    SoundManager.OpenBox();
                anim.SetTrigger("Opening");
                isOpened = true;
                Invoke("GenCoin", delayTime);

                //钥匙只能用一次，所以开箱子之后要重置钥匙状态
                isKey = false;
                //keyIndex--;
            }
        }
    }

    void GenCoin()
    {
        Instantiate(coin, transform.position, Quaternion.identity);
    }

    // 靠近就设置可以打开
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            canOpen = true;
        }
    }

    //离开就设置不能打开
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            canOpen = false;
        }
    }

}
