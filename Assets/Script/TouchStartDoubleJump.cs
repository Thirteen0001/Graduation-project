using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchStartDoubleJump : MonoBehaviour
{
    private Player_Controller player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //可以开始跳跃
        //改变 单例中的值来同步修改player中的值
        GameController.canDoubleJump = true;
    }
}
