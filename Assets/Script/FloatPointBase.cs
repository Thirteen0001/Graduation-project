using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPointBase : MonoBehaviour
{
    // 销毁时间
    public float destoryTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destoryTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
