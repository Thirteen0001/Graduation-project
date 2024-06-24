using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    //显示的背景图片
    public GameObject dialogBox;
    //显示文本
    public Text dialogBoxText;
    //实际显示的文本
    public string signText;
    // 能否打开文本框
    public bool canDialog;

    //提示款
    public GameObject tip;
    //提示文本
    public Text tipText;
    //实际提示文本
    public string currentText;

    //标记 Player 是否与告示牌接触
    private bool isPlayerInSign;

    // 切换控制模块
    #region
    private PlayerInputAction controls;

    void Awake()
    {
        // 改变输入映射
        controls = new PlayerInputAction();

        //攻击
        controls.GamePlay.ShowTip.started += ctx => ShowTip();
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //靠近开始提示
        tip.SetActive(true);
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isPlayerInSign = true;
            tipText.text = currentText;
            //Debug.Log("进入告示牌范围");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //离开关闭提示
        tip.SetActive(false);
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isPlayerInSign = false;
            dialogBox.SetActive(false);
            //Debug.Log("离开告示牌范围");
        }
    }

    void ShowTip()
    {
        if (isPlayerInSign && canDialog)
        {
            // 对话框出现后也要关掉提示
            tip.SetActive(false);
            // 显示我们需要的文本
            dialogBoxText.text = signText;
            // 显示对话框
            dialogBox.SetActive(true);
        }
    }
}
