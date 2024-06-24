using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Sprite : MonoBehaviour
{
    public int damage;

    private PlayerHealth playerHealth;



    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Player 碰到受伤
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            playerHealth.DamagePlayer(damage);
        }
    }
}
