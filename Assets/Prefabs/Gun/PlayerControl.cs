using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Animation [] girl_anim;
    private Gun gun;                            //获取枪
    public GameObject firePoint;        //获取开火点
    private Animator anim;                  //获取动画对象
   
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        firePoint = GameObject.FindGameObjectWithTag("FirePoint");
        girl_anim = this.GetComponentsInChildren<Animation>();
        //Debug.Log(girl_anim.Length);
        gun = this.GetComponentInChildren<Gun>();
        GetComponent<Rigidbody>().freezeRotation = true;
    }
    public float speed = 5;
    public float roundSpeed = 30;


    public bool ground = true;
    public float mJumpSpeed = 1f;
    // Update is called once per frame
    void Update()
    {
        Movement();
        Fire();
    }
  //  private void FixedUpdate()
  //  {
       /// transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
       // if (Input.GetKey(KeyCode.Space))
       // {
           // if (ground == true)
          //  {
               // //transform.Translate(new Vector3(Input.GetAxis("Horizontal")*distance, 2, Input.GetAxis("Vertical")*distance));
           //     GetComponent<Rigidbody>().velocity += new Vector3(0, 1, 0);
                
           //     anim.SetBool("Jump", true);
         //       GetComponent<Rigidbody>().AddForce(Vector3.up * mJumpSpeed);
          //      ground = false;
        //        Debug.Log("I am Pressing Jump");
       //     }
       // }

   // }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("碰撞发生" + other.tag);
        if(other.tag == "Zombie")
        {
            this.GetComponent<PlayerStatus>().Damage(10);
        }
    }
    /// <summary>
    /// 移动
    /// </summary>
    private void Movement()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            anim.SetBool("run", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(-Vector3.forward * speed * Time.deltaTime);
            anim.SetBool("run", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("run", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("run", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(0, -roundSpeed * Time.deltaTime, 0);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(0, roundSpeed * Time.deltaTime, 0);
        }
        //    if (Input.GetKey(KeyCode.Q))
        //    {
        //      GetComponent<Rigidbody>().velocity += new Vector3(0, 1, 0);
        //    print("调用Jump动画");
        //    Debug.Log("调用了Jump动画");
        //   anim.SetBool("Jump", true);

        // }
        //if (Input.GetKey(KeyCode.Keypad0))
        //{

        //}


        if (Input.GetKey(KeyCode.Keypad1))
        {
            anim.SetBool("Cry", true);
        }
        
    }
    private void Movement1()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        hor *= speed * Time.deltaTime;
        ver *= speed * Time.deltaTime;
        this.transform.Translate(hor, 0, ver);
    }
    /// <summary>
    /// 开火、换弹
    /// </summary>
    private void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Transform fp = firePoint.transform;
            gun.Firing(fp.forward);
        }
        if (Input.GetMouseButtonDown(1))
        {
            gun.UpdateAmmo();
        }
    }
    public Texture texture;
    private void OnGUI()
    {
        Rect rect = new Rect(Input.mousePosition.x - (texture.width >> 1),
            Screen.height - Input.mousePosition.y - (texture.height >> 1),
            texture.width, texture.height);

        GUI.DrawTexture(rect, texture);

    }
}
