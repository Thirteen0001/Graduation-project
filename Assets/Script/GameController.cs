using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    //单例模式
    public static GameController instance;

    public int health;
    public int damage;

    //保存血量和金币以及死亡次数
    public static int MaxHealth;
    public static int StartDamage;

    public static int Health;
    public static int Damage;

    public static int currentHealth;
    public static int currentCoin;
    public static int currentDead;

    public static bool isGameAlive = true;

    public static CameraShake camShake;

    //public GameObject startMenu;

    //设置复活点
    public static Vector3 startPos;

    //设置存档点
    private Vector3 lastSavePositon;

    //private int currentSceneIndex;

    public static bool canJump = false;
    public static bool canDoubleJump = false;
    public static bool canAttack = false;

    //单个存档的保存次数
    public static int isLoad = 0;

    public static bool isSave  = false;


    public void Awake()
    {
        // 确保Instance只被赋值一次  
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 确保对象在场景切换时不会被销毁  
        }
        else
        {
            // 如果Instance已经存在，销毁当前对象实例以防止重复创建  
            Destroy(gameObject);
        }

        MaxHealth = health;
        StartDamage = damage;

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            //在开始菜单设置初始信息
            currentHealth = MaxHealth;
            currentCoin = CoinUI.startCoin;
            currentDead = DeadUI.startDead;
            //Debug.Log(currentHealth);
        }
        //保存初始关卡编号
        //currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //Debug.Log("单例所记录的关卡编号为： " + currentSceneIndex);

        //清除所有的 playerPrefs 内容 导出后需要删除
        //ClearData();

       

    }

    // Start is called before the first frame update
    void Start()
    {
        //让每一关都有血量 在正式游戏中需要注销
        HealthBar.healthCurrent = MaxHealth;

        Health = MaxHealth;
        Damage = StartDamage;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Damage);

        //Debug.Log(startPos +" 保存状态 ： " +SavePoint.isSave);
        if (SavePoint.isSave)
        {
            Debug.Log("已保存");
            //如果保存了就更新复活点
            startPos = SavePoint.SavePos;
            //更新保存玩家位置
        }
        else
        {
            Debug.Log("未保存");
        }

        //如果不是开始菜单则保存现有的信息
        currentHealth = HealthBar.healthCurrent;
        currentCoin = CoinUI.currentCoinQuantity;
        currentDead = DeadUI.currentDeadQuantity;

        

    }

}
