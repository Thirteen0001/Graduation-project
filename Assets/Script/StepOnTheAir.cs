using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepOnTheAir : MonoBehaviour
{
    public float resetTime;
    public GameObject objectsAppear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Player 踩空
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            Debug.Log("触发");
            gameObject.SetActive(false);
            Invoke("ResetTime", resetTime);
            if(objectsAppear != null)
            {
                objectsAppear.SetActive(true);
            }
        }
    }

    void ResetTime()
    {
        gameObject.SetActive(true);
        if(objectsAppear != null)
        {
            objectsAppear.SetActive(false);
        }
    }
}
