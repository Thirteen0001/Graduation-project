using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//引入 UI 头文件才可以使用 UI 的组件
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadUI : MonoBehaviour
{
    //初始的数量
    public int startDeadQuantity;
    public static int startDead;

    //用于显示的组件
    public Text deadQuantity;

    //当前的金币数量
    public static int currentDeadQuantity;

    void Awake()
    {
        startDead = startDeadQuantity;

    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && GameController.isLoad == 0)
        {
            currentDeadQuantity = startDead;
        }
        else
        {
            currentDeadQuantity = GameController.currentDead;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameController.currentDead = currentDeadQuantity;
        //显示金币数量
        deadQuantity.text = "x " + currentDeadQuantity.ToString();
    }
}
