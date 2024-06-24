using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_Destory : MonoBehaviour
{
    //标记
    public int batFlag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //当对象被 销毁时触发的方法
    void OnDestroy()
    {
        EasterEgg.Password += batFlag.ToString();
        //Debug.Log(batFlag);
        //Debug.Log(EasterEgg.Password);

    }
}
