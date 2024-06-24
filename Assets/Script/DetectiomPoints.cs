using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectiomPoints : MonoBehaviour
{
    //检测点
    public GameObject detectionPoints;
    //移动的物体
    public GameObject moveSpikes;
    //初始状态
    public bool isHide;
    // X 轴移动速度
    public float xMoveSpeed;
    // Y 轴移动速度
    public float yMoveSpeed;
    // 设置重置时间
    public float resetTime;
    //设置等待时间
    public float waitTime;
    //射线距离
    //public float distance;

    private float startReSetTime;

    //保存开始位置
    private Vector3 startPosition;

    private bool reset;

    // Start is called before the first frame update
    void Start()
    {
        //保存开始位置
        startPosition = moveSpikes.GetComponent<Transform>().position;
        reset = false;
        startReSetTime = resetTime;
        if (isHide)
        {
            moveSpikes.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 定义射线
        RaycastHit2D hit = Physics2D.Raycast(detectionPoints.GetComponent<Transform>().position, Vector2.up,100f);

        if (hit.collider != null)
        {
            //如果碰到了东西
            if (hit.collider.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
            {
                Debug.Log("player经过");
                MoveSpikes();
            }

        }

        if (reset)
        {
            //消除速度
            moveSpikes.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            Invoke("ResetPosition", waitTime);
        }

        if(!GameController.isGameAlive)
        {
            Debug.Log("血量为零重置");
            reset = true;
        }
    }

    void MoveSpikes()
    {
        //不使用检测点
        detectionPoints.SetActive(false);
        moveSpikes.SetActive(true);
        moveSpikes.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveSpeed, yMoveSpeed);
        Invoke("RemoveSpeed", resetTime);
    }

    void RemoveSpeed()
    {
        reset = true;
    }

    void ResetPosition()
    {
        //重设位置
        reset = false;
        moveSpikes.SetActive(!isHide);
        moveSpikes.GetComponent<Transform>().position = startPosition;
        detectionPoints.SetActive(true);
        Debug.Log("已重设位置");
    }
}
