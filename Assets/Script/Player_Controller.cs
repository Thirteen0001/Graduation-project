using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    // 设置移动速度
    public float runSpeed;
    //设置跳跃速度
    public float jumpSpeed;
    //设置二段跳的速度
    public float doubleJumpSpeed;


    private float startRunSpeed;
    private float startJumpSpeed;
    private float startDoubleJumpSpeed;


    //设置恢复 Player 图层时间
    public float restoreTime;

    //判断是否可以跳跃
    public bool canJump;
    //判断是否可以二段跳
    public bool canDoubleJump;

    // 获取刚体组件
    private Rigidbody2D myRigidbody;
    // 获取动画状态机
    private Animator myAnim;
    //获取脚上的碰撞体
    private BoxCollider2D myFeet;
    //定义是否接触到地面
    private bool isGround;
    //定义是否可以二段跳
    public static bool DoubleJump;
    //判断是否为单向平台
    private bool isOneWayPlatform;

    // 记录按下空格键的起始时间
    private float jumpStartTime = -Mathf.Infinity;

    //判断是否在水中
    public static bool isWater = false;

    // 切换控制模块
    #region
    private PlayerInputAction controls;
    private Vector2 move;

    void Awake()
    {
        // 改变输入映射
        controls = new PlayerInputAction();
        // 移动
        controls.GamePlay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.GamePlay.Move.canceled += ctx => move = Vector2.zero;
        //跳跃
        controls.GamePlay.Jump.started += ctx => Jump();
        //单向平台
        controls.GamePlay.Lower.started += ctx => OneWayPlatformCheck();

    }

    void OnEnable()
    {
        controls.GamePlay.Enable();
    }

    void OnDisEnable()
    {
        controls.GamePlay.Disable();
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // 初始化刚体组件
        myRigidbody = GetComponent<Rigidbody2D>();
        //初始化动画状态机
        myAnim = GetComponent<Animator>();
        //初始化脚部碰撞体
        myFeet = GetComponent<BoxCollider2D>();

        //保存初值
        startJumpSpeed = jumpSpeed;
        startRunSpeed = runSpeed;
        startDoubleJumpSpeed = doubleJumpSpeed;

        //只有在第一关的时候才需要禁用跳跃和攻击
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Debug.Log("这是第一关");
            GameController.canJump = false;
            GameController.canDoubleJump = false;
            GameController.canAttack = false;
        }
        else
        {
            Debug.Log("这不是第一关");
            GameController.canJump = true;
            GameController.canDoubleJump = true;
            GameController.canAttack = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //输出移动的 x 和 y 值
        //Debug.Log(move);

        if (GameController.isGameAlive)
        { 
            //持续调用函数
            Flip();
            //原始移动方法

            //新版本移动方法
            //NewRun();
            //跳跃已经变成实时触发 不需要再 Updata 方法中调用
            //Jump();

            //OneWayPlatformCheck();
            canJump = GameController.canJump;
            canDoubleJump = GameController.canDoubleJump;

            IntoWater();

        }
    }

    void FixedUpdate()
    {
        //判断地面函数
        CheckGrounded();
        //切换动画函数
        SwitchAnimation();
        //移动函数
        Run();


    }

    //接触到地面判定函数
    void CheckGrounded()
    {
        //把接触到的 地板 移动平台 单向平台 都视为 地面
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))
                || myFeet.IsTouchingLayers(LayerMask.GetMask("MovingPlatform"))
                || myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
        // 碰到单项平台 赋值为 true
        isOneWayPlatform = myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
    }

    //反转人物贴图函数
    void Flip()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasXAxisSpeed)
        {
            //如果速度是正就不反转
            if(myRigidbody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            //如果速度是负数就反转
            if (myRigidbody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    //移动函数
    void Run()
    {
        // 原版基础控制移动  由于改变了输入方式所以舍弃
        //float moveDir = Input.GetAxisRaw("Horizontal");
        //Vector2 playerVel = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
        //myRigidbody.velocity = playerVel;

        Vector2 playerVel = new Vector2(move.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVel;

        //控制 Idle 和 Run 的动画切换
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnim.SetBool("Run", playerHasXAxisSpeed);
    }

    //新版移动函数
    void NewRun()
    {
        Vector2 vector2 = transform.position;
        myRigidbody.MovePosition(vector2 + move * Time.fixedDeltaTime);


        //控制 Idle 和 Run 的动画切换
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnim.SetBool("Run", playerHasXAxisSpeed);
    }

    //原版跳跃函数
    void Jump()
    {
        //触发条件 如果可以跳跃，按下空格则可以跳跃，否则不允许跳跃  
        if (canJump && GameController.isGameAlive && GameController.canJump)
        {
            if (isGround)
            {
                //Debug.Log("地面判断开始");

                //播放跳跃音效
                SoundManager.PlayerJump();

                //如果跳起来了就给 Jump 属性赋值为 true 并且执行跳跃动作
                myAnim.SetBool("Jump",true);
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                myRigidbody.velocity = Vector2.up * jumpVel;

                DoubleJump = true;
            }
            else
            {
                if (DoubleJump && canDoubleJump)
                {
                    //播放跳跃音效
                    SoundManager.PlayerJump();

                    myAnim.SetBool("DoubleJump", true);
                    myAnim.SetBool("DoubleFall", false);
                    //myAnim.SetBool("Fall", false);
                    Vector2 doubleJumpVel=new Vector2(0.0f, doubleJumpSpeed);
                    myRigidbody.velocity=Vector2.up* doubleJumpVel;
                    DoubleJump = false;
                }
            }
        }
    }

    //跳跃切换动画
    public void SwitchAnimation()
    {
        myAnim.SetBool("Idle", false);
        if (myAnim.GetBool("Jump"))
        {
            if (myRigidbody.velocity.y < 0.0f)
            {
                myAnim.SetBool("Jump", false);
                myAnim.SetBool("Fall", true);
            }
        }
        else if (isGround)
        {
            myAnim.SetBool("Fall", false);
            myAnim.SetBool("Jump", false);
            myAnim.SetBool("Idle", true);
            myAnim.SetBool("NotGround", true);

            //播放碰到地面音效
            //SoundManager.PlayerFall();
        }

        // 二段跳的动画切换
        if (myAnim.GetBool("DoubleJump"))
        {
            if (myRigidbody.velocity.y < 0.0f)
            {
                myAnim.SetBool("DoubleJump", false);
                myAnim.SetBool("DoubleFall", true);
            }
        }
        else if (isGround)
        {
            myAnim.SetBool("DoubleFall", false);
            myAnim.SetBool("DoubleJump", false);
            myAnim.SetBool("Idle", true);
            myAnim.SetBool("NotGround", true);

            //播放碰到地面音效
            //SoundManager.PlayerFall();
        }

        //当未在任何一个动作状态时候 可以理解为在 idle 或 run 状态的时候，下落需要切换下落动画
        bool notJump = myAnim.GetBool("Idle") || myAnim.GetBool("Run");
        if (!isGround && notJump)
        {
            myAnim.SetBool("NotGround", false);
        }
    }

    // 判断是否触发 单项平台 函数
    void OneWayPlatformCheck()
    {
        // 还原图层
        if (isGround && gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }

        // 获取 Y 轴的速度 如果 Y 轴速度是向下代表 我们想往下走
        //float moveY = Input.GetAxisRaw("Vertical");
        //Debug.Log("触发函数");
        if (isOneWayPlatform)
        {
            //Debug.Log("可下落");

            gameObject.layer = LayerMask.NameToLayer("OneWayPlatform");
            Invoke("RestorePlayerLayer", restoreTime);
        }
    }

    //获取 Player Layer
    void RestorePlayerLayer()
    {
        if (!isGround && gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
    }

    //进入水就改变数值
    void IntoWater()
    {
        if (isWater)
        {
            Debug.Log("开始无限跳");
            //重力变成0.5倍
            myRigidbody.gravityScale = Water.currentGravityScale;
            //移速和跳跃都减半
            runSpeed = startRunSpeed * Water.currentRunSpeedScale;
            jumpSpeed = startJumpSpeed * Water.currentJumpSpeedScale;
            doubleJumpSpeed = startDoubleJumpSpeed * Water.currentJumpSpeedScale;
            DoubleJump = true;
        }
        else
        {
            //还原数值
            myRigidbody.gravityScale = 1f;
            jumpSpeed = startJumpSpeed;
            runSpeed = startRunSpeed;
            doubleJumpSpeed = startDoubleJumpSpeed;

        }
    }
}
