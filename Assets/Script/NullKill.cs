using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullKill : MonoBehaviour
{
    private PlayerHealth playerHealth;

    public int damage;


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        //此方法用与放在player会落成摄像机外的情况，直接处死player
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            Debug.Log("碰到了");
            playerHealth.DamagePlayer(damage);
        }
    }
}
