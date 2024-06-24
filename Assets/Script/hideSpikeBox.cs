

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideSpikeBox : MonoBehaviour
{
    //定义伤害值
    public int damage;
    //定义销毁时间
    public float destroyTime;

    //获取player的血量
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        //一段时候后销毁
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            playerHealth.DamagePlayer(damage);
        }
    }
}
