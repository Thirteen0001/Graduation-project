using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    // 特效播放时间，超时就销毁
    public float timeToDestory;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,timeToDestory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
