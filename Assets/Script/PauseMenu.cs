using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    //记录当前状态是否是暂停状态
    private static bool gameIsPaused = false;

    public GameObject pauseMenu;
    public GameObject comfirmSaveGame;
    public GameObject player;

    // 切换控制模块
    #region
    private PlayerInputAction controls;

    void Awake()
    {
        // 改变输入映射
        controls = new PlayerInputAction();

        //攻击
        controls.GamePlay.OpenPauseMenu.started += ctx => OpenPauseMenu();
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
        //Debug.Log(gameIsPaused);
    }

    void OpenPauseMenu()
    {
        //不是在主菜单时才可以打开暂停页面
        if(SceneManager.GetActiveScene().buildIndex != 0 && !Merchant.isOpen)
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // 返回方法
    public void Resume()
    {
        // 关闭 UI
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        PlayerHealth.EnablePlayerController();
        player.GetComponent<Player_Controller>().enabled = true;
        gameIsPaused = false;
    }

    // 暂停
    public void Pause()
    {
        // 显示 UI
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        PlayerHealth.DisablePlayerController();
        player.GetComponent<Player_Controller>().enabled = false;
        gameIsPaused = true;
    }

    //回到主菜单
    public void MainMenu()
    {
        if (GameController.isSave || SceneManager.GetActiveScene().name == "End")
        {
            gameIsPaused = false;
            Time.timeScale = 1.0f;
            PlayerHealth.EnablePlayerController();
            player.GetComponent<Player_Controller>().enabled = true;
            SceneManager.LoadScene("Menu");
        }
        else
        {
            comfirmSaveGame.SetActive(true);
        }
    }

    public void QuitGame()
    {
        if (GameController.isSave || SceneManager.GetActiveScene().name == "End")
        {
            Application.Quit();
        }
        else
        {
            comfirmSaveGame.SetActive(true);
        }
    }

    public void CloseSaveGame()
    {
        comfirmSaveGame.SetActive(false);
    }
}
