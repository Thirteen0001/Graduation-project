using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDoubleJump : MonoBehaviour
{
    public float resetTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Player 碰到刷新二段跳
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            //碰到就隐藏
            gameObject.SetActive(false);
            //规定时间后恢复
            Invoke("ResetSelf", resetTime);

            Player_Controller.DoubleJump = true;
        }
    }

    void ResetSelf()
    {
        gameObject.SetActive(true);
    }
}
