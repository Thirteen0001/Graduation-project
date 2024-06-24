using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    // 获取进度条
    public GameObject loadingScreen;
    //获取参数
    public Slider slider;
    //获取显示数字的文本
    public Text progressText;

    //获取开始菜单
    public GameObject startMenu;
    public GameObject settingMenu;
    public GameObject ComfirmGame;
    //控制声音进度条
    public Slider soundSlider;

    // 关联到UI中的Toggle组件
    public Toggle fullScreenToggle;
    // 用于保存全屏设置的键
    private const string FULL_SCREEN_PREF_KEY = "IsFullScreen";

    public GameObject clearSuccess;


    // Start is called before the first frame update
    void Start()
    {
        // 初始化时从PlayerPrefs加载全屏设置  
        bool isFullScreen = PlayerPrefs.GetInt(FULL_SCREEN_PREF_KEY, 0) == 1;
        fullScreenToggle.isOn = isFullScreen;
        // 设置当前的屏幕模式以匹配加载的设置  
        Screen.fullScreen = isFullScreen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFullScreenToggleValueChanged()
    {
        // 当Toggle的值改变时，切换全屏模式并保存设置  
        Screen.fullScreen = fullScreenToggle.isOn;
        PlayerPrefs.SetInt(FULL_SCREEN_PREF_KEY, fullScreenToggle.isOn ? 1 : 0);
        PlayerPrefs.Save(); // 确保设置被保存  
    }

    // 加载关卡
    public void LoadLevel(int sceneIndex)
    {
        //StartCoroutine(AsyncLoadLevel(sceneIndex));

        //如果关卡还是初始化的值说明没有保存过 可以直接加载
        if (PlayerPrefs.GetInt("Level")==0)
        {
            StartCoroutine(AsyncLoadLevel(sceneIndex));
        }
        else
        {
            ComfirmGame.SetActive(true);
        }
    }

    public void ConfirmNewGame()
    {
        CloseComfirm();
        StartCoroutine(AsyncLoadLevel(1));
    }
    public void CloseComfirm()
    {
        ComfirmGame.SetActive(false);
    }

    IEnumerator AsyncLoadLevel(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);

        // 初始化游戏属性
        GameController.isLoad = 0;
        GameController.isSave = false;
        GameController.MaxHealth = GameController.Health;
        GameController.StartDamage = GameController.Damage;

        while (!operation.isDone)
        {
            //进度条是在 0 - 1 之间，除以0.9 就可以变成百分比小数
            float progress = operation.progress / 0.9f;
            slider.value = progress;
            progressText.text = Mathf.FloorToInt(progress * 100f) + "%";
            yield return null;
        }
    }

    //打开设置
    public void ShowSettingMenu()
    {
        //打开设置按钮
        //startMenu.SetActive(false);
        settingMenu.SetActive(true);
    }

    //关闭设置
    public void ShowStartMenu()
    {
        //startMenu.SetActive(true);
        settingMenu.SetActive(false);
    }

    //退出游戏
    public void QuitGame()
    {
        Application.Quit();
    }

    //清除存档数据 供外部调用
    public void ClearData()
    {
        SaveData.DeleteAllPlayerPrefs();
        Debug.Log("清除成功");
        clearSuccess.SetActive(true);
        Invoke("SetFalse",1f);
    }

    void SetFalse()
    {
        clearSuccess.SetActive(false);
    }
}
