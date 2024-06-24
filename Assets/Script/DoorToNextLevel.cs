using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorToNextLevel : MonoBehaviour
{
    //判断是否碰到 flag
    private bool triggerFlag;

    // 关卡编号
    public int levelIndex;

    private GameObject player;

    // 获取进度条
    public GameObject loadingScreen;
    //获取参数
    public Slider slider;
    //获取显示数字的文本
    public Text progressText;


    // 切换控制模块
    #region
    private PlayerInputAction controls;

    void Awake()
    {
        // 改变输入映射
        controls = new PlayerInputAction();

        //攻击
        controls.GamePlay.NextLevel.started += ctx => NextLevel();
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
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextLevel()
    {
        //当碰到 flag 时按下 W 才会切换下一关
        if (triggerFlag)
        {
            //保存 血量和 金币的数量
            //SaveData();
            // 切换关卡 这里使用 协程 来加载进度条
            StartCoroutine(AsyncLoadLevel());
            //SceneManager.LoadScene(levelIndex);

            //切换保存状态
            SavePoint.isSave = false;
            triggerFlag = false;
            //GameController.startPos = player.transform.position;
        }
    }

    IEnumerator AsyncLoadLevel()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            //进度条是在 0 - 1 之间，除以0.9 就可以变成百分比小数
            float progress = operation.progress / 0.9f;
            slider.value = progress;
            progressText.text = Mathf.FloorToInt(progress * 100f) + "%";
            yield return null;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            triggerFlag = true;
        }
    }

    //public void SaveData()
    //{
    //    Debug.Log(CoinUI.currentCoinQuantity);
    //    Debug.Log(HealthBar.healthCurrent);

    //    PlayerPrefs.SetInt("PlayerHealth", HealthBar.healthCurrent);
    //    PlayerPrefs.SetInt("PlayerCoins", CoinUI.currentCoinQuantity);

    //    Debug.Log(PlayerPrefs.GetInt("PlayerHealth"));
    //    Debug.Log(PlayerPrefs.GetInt("PlayerCoins"));

    //    PlayerPrefs.Save();
    //}

}
