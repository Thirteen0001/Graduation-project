using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //跟随的目标
    public Transform target;
    //让相机运动的更平滑  平滑因子
    public float smoothing;

    //最小移动坐标
    public Vector2 minPosition;
    //最大移动坐标
    public Vector2 maxPosition;

    // Start is called before the first frame update
    void Start()
    {
        GameController.camShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            if(transform.position != target.position)
                {
                    Vector3 targetPos = target.position;
                    targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
                    targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);
                    //  线性插值
                    transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
                }
        }
    }

    // 给其他类调用
    public void SetCamPosLimit(Vector2 minPos,Vector2 maxPos)
    {
        minPosition = minPos;
        maxPosition = maxPos;
    }
}
