using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightOarRotation : MonoBehaviour
{
    GameObject LeftOar;
    GameObject RightOar;
    float LeftOarY = 0;
    float RightOarY = 0;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        //オールの先端を取得
        this.RightOar = GameObject.Find("RightOarTop");
    }

    // Update is called once per frame
    void Update()
    {
        OarRotation();
    }


    //オールの水中判定
    void OarRotation()
    {
        this.RightOarY = this.RightOar.transform.position.y;

        //水中で力を加えているとき、動きが遅くなる
        if (RightOarY < 0)
        {
            speed = 30 * 5;
        }
        else
        {
            speed = 12 * 5;
        }

        transform.Rotate(new Vector3(-25, 2, 10) / speed);

    }
}
