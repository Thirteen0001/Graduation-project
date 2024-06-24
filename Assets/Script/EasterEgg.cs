using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    //彩蛋触发密码
    public string easterEggPassword;
    //可被外部改变的变量
    public static string Password;

    //获取金币预制体
    public GameObject coin;
    //生成金币的数量
    public int coinQuantity;
    //金币的速度
    public float coinUpSpeed;
    //生成金币的间隔时间
    public float intervalTime;

    public GameObject endPoint;

    public GameObject[] enemy;



    // Start is called before the first frame update
    void Start()
    {
        Password = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(Password == easterEggPassword)
        {
            Debug.Log("触发彩蛋");
            Password = "";
            
            StartCoroutine(GenCoins());
        }

        if (enemy[0] ==null && enemy[1] == null && enemy[2] == null && enemy[3] == null)
        {
            Debug.Log("敌人被全部清除");

            endPoint.SetActive(true);
        }
    }

    IEnumerator GenCoins()
    {
        WaitForSeconds wait = new WaitForSeconds(intervalTime);
        for(int i = 0;i< coinQuantity; i++)
        {
            GameObject gb = Instantiate(coin,transform.position, Quaternion.identity);
            Vector2 randomDirection = new Vector2(Random.Range(-0.3f, 0.3f), 1.0f);
            gb.GetComponent<Rigidbody2D>().velocity = randomDirection * coinUpSpeed;
            yield return wait;
        }
    }
}
