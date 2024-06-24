using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float gravityScale;
    public float runSpeedScale;
    public float jumpSpeedScale;

    public static float currentGravityScale;
    public static float currentRunSpeedScale;
    public static float currentJumpSpeedScale;

    // Start is called before the first frame update
    void Start()
    {
        currentGravityScale = gravityScale;
        currentJumpSpeedScale = jumpSpeedScale;
        currentRunSpeedScale = runSpeedScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            Player_Controller.isWater = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            Player_Controller.isWater = false;
        }
    }
}
