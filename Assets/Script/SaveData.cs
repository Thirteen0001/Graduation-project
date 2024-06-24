using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    public GameObject noSaveData;

    private int index;
    private int coin;
    private int level;
    private int damage;
    private int maxHealth;
    //private Vector3 pos;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    

    #region Save and Load
    //保存
    public void Save()
    {
        GetData();

        SaveByPlayerPrefs();
    }

    //读取
    public void Load()
    {

        //如果是菜单页面
        if (PlayerPrefs.GetInt("Level") != 0)
        {
            Debug.Log("载入成功");
            LoadFromPlayerPrefs();
        }
        else
        {
            Debug.Log("没有存档数据");
            noSaveData.SetActive(true);
            Invoke("SetFalse", 1f);
        }
    }

    void SetFalse()
    {
        noSaveData.SetActive(false);
    }

    #endregion

    #region PlayerPrefs
    void SaveByPlayerPrefs()
    {
        //存储数据
        PlayerPrefs.SetInt("Index",index);
        PlayerPrefs.SetInt("Coin", coin);
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.SetInt("Damage", damage);
        PlayerPrefs.SetInt("MaxHealth", maxHealth);
        
        //PlayerPrefs.SetFloat("PosX",pos.x);
        //PlayerPrefs.SetFloat("PosY", pos.y);
        //PlayerPrefs.SetFloat("PosZ", pos.z);
        //确认保存数据
        PlayerPrefs.Save();
        Debug.Log("保存成功");
        GameController.isSave = true;

        //播放音效
        SoundManager.SaveSuccessful();
    }

    void LoadFromPlayerPrefs()
    {
        CoinUI.currentCoinQuantity = PlayerPrefs.GetInt("Coin");
        GameController.currentCoin = PlayerPrefs.GetInt("Coin");

        DeadUI.currentDeadQuantity = PlayerPrefs.GetInt("Index");
        GameController.currentDead = PlayerPrefs.GetInt("Index");

        //加载伤害
        GameController.StartDamage = PlayerPrefs.GetInt("Damage");
        //加载血量
        GameController.MaxHealth = PlayerPrefs.GetInt("MaxHealth");

        //加载关卡
        int level = PlayerPrefs.GetInt("Level");
        SceneManager.LoadScene(level);

        //重设保存点
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //SavePoint.SavePos = new Vector3(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"), PlayerPrefs.GetFloat("PosZ"));
        //player.position = SavePoint.SavePos;

        GameController.isLoad += 1;
    }
    #endregion

    //用于清除所有的 PlayerPrefs 中保存的值
    public static void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    //获取所有初始数据
    void GetData()
    {
        //获取数据
        coin = CoinUI.currentCoinQuantity;
        index = DeadUI.currentDeadQuantity;
        //health = HealthBar.healthCurrent;
        //pos = SavePoint.SavePos;
        level = SceneManager.GetActiveScene().buildIndex;
        damage = GameController.StartDamage;
        maxHealth = GameController.MaxHealth;

        //Debug.Log("数据获取成功");
        //Debug.Log("金币数量是： " + coin);
        //Debug.Log("血量是：" + health);
        //Debug.Log("当前位置是：" + pos);
        //Debug.Log("当前关卡编号是：" + level);

    }
}
