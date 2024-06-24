using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private Animator anim;

    public static bool isSave;

    private int saveState;

    public static Vector3 SavePos;

    // Start is called before the first frame update
    void Start()
    {
        saveState = 0;
        isSave = false;
        anim = GetComponent<Animator>();
        //SavePos = GetComponent<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 碰到就保存
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (saveState == 0)
            {
                //播放保存音效
                SoundManager.SaveSuccessful();

                //Debug.Log("已保存");
                //设置保存状态
                anim.SetTrigger("Save");
                //更新保存点
                SavePos = transform.position;
                //已经保存
                isSave = true;
                //Debug.Log("transform.position:  " + transform.position);
                //Debug.Log("SavePos:  " + SavePos);
                saveState++;
            }
        }
    }
}
