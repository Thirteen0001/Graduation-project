using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Merchant : MonoBehaviour
{
    public GameObject storePage;
    public Text damage;
    public Text health;
    public GameObject player;
    public GameObject successPage;
    public GameObject failPage;

    public float dertroyTime;

    public int price;


    //是否在范围内
    private bool isTrigger;
    //是否打开了商店页面 就不能在按暂停
    public static bool isOpen;

    

    // 切换控制模块
    #region
    private PlayerInputAction controls;

    void Awake()
    {
        // 改变输入映射
        controls = new PlayerInputAction();

        //打开关闭商店页面
        controls.GamePlay.Open_Store.started += ctx => ChangeStoreState();
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
        isTrigger = false;
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "       x " + price.ToString();
        damage.text = "       x " + price.ToString();
    }

    //触发在范围内
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isTrigger = true;
            Debug.Log("在范围内");
        }
    }
    //离开则不在范围内
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isTrigger = false;
        }
    }

    void ChangeStoreState()
    {
        //如果没有打开则打开 如果打开了则关闭
        if (!isOpen)
        {
            OpenStore();
        }
        else
        {
            CloseStore();
        }
    }

    void OpenStore()
    {
        //在范围内则按 E 可以触发商店
        if(isTrigger)
        {
            isOpen = true;
            storePage.SetActive(true);
            //禁用操作
            PlayerHealth.DisablePlayerController();
            player.GetComponent<Player_Controller>().enabled = false;
        }
    }

    public void CloseStore()
    {
        Debug.Log("关闭页面");
        isOpen = false;
        storePage.SetActive(false);
        //启用操作
        PlayerHealth.EnablePlayerController();
        player.GetComponent<Player_Controller>().enabled = true;
    }

    //添加血量
    public void AddHealth()
    {
        if (GameController.currentCoin>= price)
        {
            //减少金币
            CoinUI.currentCoinQuantity -= price;
            successPage.SetActive(true);
            Invoke("DisableTip", dertroyTime);

            GameController.MaxHealth++;

            Debug.Log("健康值加一");
        }
        else
        {
            failPage.SetActive(true);
            Invoke("DisableTip", dertroyTime);
        }
    }

    //添加攻击力
    public void AddAttack()
    {
        if (GameController.currentCoin >= price)
        {
            //减少金币
            CoinUI.currentCoinQuantity -= price;
            successPage.SetActive(true);
            Invoke("DisableTip", dertroyTime);

            //初始攻击力加一
            GameController.StartDamage++;

            Debug.Log("攻击力加一");
        }
        else
        {
            failPage.SetActive(true);
            Invoke("DisableTip", dertroyTime);
        }
    }

    void DisableTip()
    {
        failPage.SetActive(false);
        successPage.SetActive(false);
    }
}
