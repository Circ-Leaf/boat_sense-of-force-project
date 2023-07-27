using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ButtonScript : MonoBehaviour
{
    //ファイル書き込み関係
    public float timeOut = 0.7f;
    private float timeElapsed;

    public void StartMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void CloseWindow()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        StreamWriter sw = new StreamWriter("D:/エレデザ完成品/テキストファイル/PowerData.txt", false);  //false:上書き保存 true:追記
        sw.WriteLine(0);  //メインシーン以外の時、出力は0
        sw.Flush();
        sw.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
