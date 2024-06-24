using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    //获取进度条
    public Slider volumeSlider;

    // 获取音源
    public static AudioSource audioSrc;
    //获取音效
    public static AudioClip attackNull;     //挥剑但未砍到物体
    public static AudioClip attackEnemy;    //挥剑砍到怪物
    public static AudioClip pickUpCoin;     //捡起金币
    public static AudioClip playerWounded;  //主角受伤
    public static AudioClip playerDead;     //主角死亡
    public static AudioClip playerJump;     //主角跳起
    public static AudioClip playerFall;     //主角落地
    public static AudioClip portals;        //传送门
    public static AudioClip saveSuccessful; //保存成功
    public static AudioClip openBox;        //打开箱子
    public static AudioClip pickUpTheKeys;  //打开箱子




    // Start is called before the first frame update
    void Start()
    {
        //初始化时同步Slider的值和音量
        SyncVolumeWithSlider();

        // 初始化 音源
        audioSrc = GetComponent<AudioSource>();
        //初始化 音效
        attackNull = Resources.Load<AudioClip>("AttackNull");
        attackEnemy = Resources.Load<AudioClip>("AttackEnemy");
        pickUpCoin = Resources.Load<AudioClip>("PickUpCoin");
        playerWounded = Resources.Load<AudioClip>("PlayerWounded");
        playerDead = Resources.Load<AudioClip>("PlayerDead");
        playerJump = Resources.Load<AudioClip>("PlayerJump");
        playerFall = Resources.Load<AudioClip>("PlayerFall");
        portals = Resources.Load<AudioClip>("Portals");
        saveSuccessful = Resources.Load<AudioClip>("SaveSuccessful");
        openBox = Resources.Load<AudioClip>("OpenBox");
        pickUpTheKeys = Resources.Load<AudioClip>("PickUpTheKeys");



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 当Slider的值改变时调用此方法  
    public void OnVolumeSliderValueChanged()
    {
        // 设置音量  
        AudioListener.volume = volumeSlider.value;
    }

    // 同步Slider的值和音量  
    public void SyncVolumeWithSlider()
    {
        volumeSlider.value = AudioListener.volume;
    }

    // 挥空武器函数
    public static void AttackNull()
    {
        audioSrc.PlayOneShot(attackNull);
    }

    // 击中敌人函数
    public static void AttackEnemy()
    {
        audioSrc.PlayOneShot(attackEnemy);
    }

    // 捡起金币函数
    public static void PickUpCoin()
    {
        audioSrc.PlayOneShot(pickUpCoin);
    }

    //主角受伤
    public static void PlayerWounded()
    {
        audioSrc.PlayOneShot(playerWounded);
    }

    // 主角死亡
    public static void PlayerDead()
    {
        audioSrc.PlayOneShot(playerDead);
    }

    //主角跳起
    public static void PlayerJump()
    {
        audioSrc.PlayOneShot(playerJump);
    }

    //主角碰到地面
    public static void PlayerFall()
    {
        audioSrc.PlayOneShot(playerFall);
    }

    //传送门
    public static void Portals()
    {
        audioSrc.PlayOneShot(portals);
    }

    //保存成功
    public static void SaveSuccessful()
    {
        audioSrc.PlayOneShot(saveSuccessful);
    }

    //打开箱子
    public static void OpenBox()
    {
        audioSrc.PlayOneShot(openBox);
    }

    //捡起钥匙
    public static void PickUpTheKeys()
    {
        audioSrc.PlayOneShot(pickUpTheKeys);
    }
}
