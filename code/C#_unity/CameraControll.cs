using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    private GameObject MainCamera;      //メインカメラ格納用
    private GameObject SubCamera;       //サブカメラ格納用 
    private GameObject FrontCamera;     //フロントカメラ格納用
    private GameObject OarCamera;       //オールカメラ格納用


    //呼び出し時に実行される関数
    void Start()
    {
        //各カメラをそれぞれ取得
        MainCamera = GameObject.Find("MainCamera");
        SubCamera = GameObject.Find("SubCamera");
        FrontCamera = GameObject.Find("FrontCamera");
        OarCamera = GameObject.Find("OarCamera");

        //各カメラを非アクティブにする
        SubCamera.SetActive(false);
        FrontCamera.SetActive(false);
        OarCamera.SetActive(false);
    }


    void Update()
    {
        //キーが押されている間、各カメラをアクティブにする
        if (Input.GetKey("1"))
        {
            //サブカメラをアクティブに設定
            MainCamera.SetActive(false);
            SubCamera.SetActive(true);
            FrontCamera.SetActive(false);
            OarCamera.SetActive(false);
        }
        else if (Input.GetKey("2"))
        {
            //フロントカメラをアクティブに設定
            SubCamera.SetActive(false);
            MainCamera.SetActive(false);
            FrontCamera.SetActive(true);
            OarCamera.SetActive(false);
        }
        else if (Input.GetKey("3"))
        {
            //オールカメラをアクティブに設定
            SubCamera.SetActive(false);
            MainCamera.SetActive(false);
            FrontCamera.SetActive(false);
            OarCamera.SetActive(true);
        }
        else
        {
            //メインカメラをアクティブに設定
            SubCamera.SetActive(false);
            MainCamera.SetActive(true);
            FrontCamera.SetActive(false);
            OarCamera.SetActive(false);
        }
    }
}