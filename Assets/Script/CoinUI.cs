using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//引入 UI 头文件才可以使用 UI 的组件
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CoinUI : MonoBehaviour
{
    //初始的数量
    public int startCoinQuantity;
    public static int startCoin;

    //用于显示的组件
    public Text coinQuantity;

    //当前的金币数量
    public static int currentCoinQuantity;

    void Awake()
    {
        startCoin = startCoinQuantity;
        //startCoinQuantity = startCoin;
    }


    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && GameController.isLoad == 0)
        {
            currentCoinQuantity = startCoin;
            Debug.Log("初始化金币数量");
        }
        else
        {
            currentCoinQuantity = GameController.currentCoin;
            Debug.Log("继承金币数量");
        }

        //currentCoinQuantity = startCoin;

        //currentCoinQuantity = startCoinQuantity;
    }

    // Update is called once per frame
    void Update()
    {
        //把实时金币赋值到单例中用于传递到下一关
        GameController.currentCoin = currentCoinQuantity;
        //显示金币数量
        coinQuantity.text = "x " + currentCoinQuantity.ToString();

        //Debug.Log(GameController.currentCoin);
        //Debug.Log(currentCoinQuantity);

    }
}
