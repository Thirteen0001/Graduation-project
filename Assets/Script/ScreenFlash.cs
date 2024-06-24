using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
    //获取图片
    public Image img;
    //闪烁时间
    public float time;
    //闪烁颜色
    public Color flashColor;
    // 保留原有的颜色
    private Color defaultColor;

    // Start is called before the first frame update
    void Start()
    {
        // 获取原有的颜色
        defaultColor = img.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlashScreen()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        //改变颜色
        img.color = flashColor;
        yield return new WaitForSeconds(time);
        img.color = defaultColor;
    }

}
