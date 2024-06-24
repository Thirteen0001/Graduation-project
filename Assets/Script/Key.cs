using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // 一次只能捡一个钥匙
            //if (TreasureBox.isKey)
            {
                TreasureBox.isKey = true;
                //TreasureBox.keyIndex++;
                Debug.Log("捡起钥匙");
                SoundManager.PickUpTheKeys();
                //销毁自身
                Destroy(gameObject);
            }
            
        }
    }
}
