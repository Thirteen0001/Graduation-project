using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirWall : MonoBehaviour
{
    public GameObject enemy;
    public GameObject sign;
    public GameObject savePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy == null && !SavePoint.isSave)
        {
            Debug.Log("敌人已经清除");
            sign.SetActive(true);
            savePoint.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
