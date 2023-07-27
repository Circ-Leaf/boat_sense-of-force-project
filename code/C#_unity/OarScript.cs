using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class OarScript : MonoBehaviour
{

    //流体の密度
    float waterDensity = 997f;
    //物体の形に依存する定数
    float objectConstant = 1;
    //進行方向の断面積(オール0.5*0.2)
    float frontArea = 0.1f;
    //物体の速度
    float speed = 100;

    //抗力
    float Drag = 0;
    //浮力
    float floatForce = 0;
    //合力
    float CombinedForce = 0;

    //オール関係
    GameObject LeftOar;
    GameObject RightOar;
    float LeftOarY = 0;
    float RightOarY = 0;

    //方向転換関係
    public float steerSpeed = 1.0f;
    public float movementThresold = 10.0f;
    float horizontalInput;
    float steerFactor;

    GameObject Boat;
    GameObject LOT; //LeftOarTopオブジェクト
    ObjectFloatScript script;


    //ファイル書き込み関係
    public float timeOut = 0.7f;
    private float timeElapsed;

    //速度制限用
    [SerializeField]
    float LimitSpeed;


    void Start()
    {
        //オールの先端を取得
        this.LeftOar = GameObject.Find("LeftOarTop");
        this.RightOar = GameObject.Find("RightOarTop");

        Boat = GameObject.Find("Boat");
        //script = Boat.GetComponent<ObjectFloatScript>();

        LOT = GameObject.Find("LeftOarTop");
        script = LOT.GetComponent<ObjectFloatScript>();
    }


    void Update()
    {
        //浮力
        floatForce = script.floating;
        if (floatForce < 0)
        {
            floatForce = 0;
        }
        Debug.Log ("合力は" + floatForce);
         

        //抗力を計算
        Drag = (waterDensity * objectConstant * frontArea * (speed * speed)) / 2;
        //Debug.Log("抗力は" + Drag);

        //合力を計算
        float x = Drag + floatForce;
        CombinedForce = Mathf.Sqrt(x);
        //Debug.Log("合力は" + CombinedForce);

        Steer();
        WaterCheck();
        Reset();

        // Rigidbody取得
        Rigidbody rb = this.transform.GetComponent<Rigidbody>();
        // 現在の速度をログに表示
        //Debug.Log(rb.velocity.magnitude);
        //speed = rb.velocity.magnitude;

        //Rigidbody Lrb = LOT.transform.GetComponent<Rigidbody>();
        //Debug.Log(Lrb.velocity.magnitude);



        //ファイル書き込み(CombinedForce)
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeOut)  //timeOut[ms]経過したら実行
        {

            StreamWriter sw = new StreamWriter("D:/エレデザ完成品/テキストファイル/PowerData.txt", false);  //false:上書き保存 true:追記
            sw.WriteLine(floatForce); //floatForceをファイル書き出し
            sw.Flush();
            sw.Close();

            timeElapsed = 0.0f;
        }

        
        //シミュレーション終了
        if (Input.GetKey("0"))
        {
            SceneManager.LoadScene("EndScene");
        }

    }


    //速度制限
    void FixedUpdate()
    {
        Rigidbody rb = this.transform.GetComponent<Rigidbody>();

        if (rb.velocity.magnitude > LimitSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x / 1.1f, rb.velocity.y, rb.velocity.z / 1.1f);
        }
    }


    //ボートの左右の動き
    void Steer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        steerFactor = Mathf.Lerp(steerFactor, horizontalInput * CombinedForce, Time.deltaTime / movementThresold);
        //transform.Rotate(0.0f, steerFactor, 0.0f);
    }


    //オールの水中判定
    void WaterCheck()
    {
        this.LeftOarY = this.LeftOar.transform.position.y;
        this.RightOarY = this.RightOar.transform.position.y;


        //両オールが水中で力を加えているとき、進む
        if (LeftOarY < 0 && RightOarY < 0)
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();             //rigidbodyを取得
            Vector3 force = new Vector3(-steerFactor, 0.0f, -CombinedForce);   //力を設定
            rb.AddForce(force);                                        //力を加える
        }
    }


    //シーンのリセット
    void Reset()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}