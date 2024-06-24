using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
//引入UI的命名空间
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //获取 UI 的 Text 组件
    public Text healthText;
    //记录当前血量
    public static int healthCurrent;
    //记录最大血量
    public static int healthMax;

    // 获取血量的 UI
    private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)healthCurrent / (float)healthMax;
        healthText.text = healthCurrent.ToString()+"/"+healthMax.ToString();
    }
}
