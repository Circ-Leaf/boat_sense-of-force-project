using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//このプログラムを適用したとき、自動でRigidbodyを追加する
[RequireComponent(typeof(Rigidbody))]


public class ObjectFloatScript : MonoBehaviour
{
	//水面の高さ
	public float waterLevel = 0.0f;

	//物体に上向きに加わる力
	public float floatThreshold = 2.0f;

	//物体に下向きに加わる力
	public float downForce = 4.0f;

	//水の密度
	public float waterDensity = 0.125f;

	//物体が水面に対してどのように入ったか（上から、水面で、下からなど）
	private float forceFactor;

	//最終的に物体に加わる力（浮力）//private>>public
	private Vector3 floatForce;

	//別スクリプトで呼び出す用
	public float floating;

	//物理演算のため、一定時間感覚で動くFixedUpdateを使用
	void FixedUpdate()
	{
		forceFactor = 1.0f - ((transform.position.y - waterLevel) / floatThreshold);

		if (forceFactor > 0.0f)
		{
			//浮力 ＝ 重力加速度 * 物体の体積 * 流体の密度
			floatForce = -Physics.gravity * GetComponent<Rigidbody>().mass * (forceFactor - GetComponent<Rigidbody>().velocity.y * waterDensity);
			floatForce += new Vector3(0.0f, -downForce * GetComponent<Rigidbody>().mass, 0.0f);
			GetComponent<Rigidbody>().AddForceAtPosition(floatForce, transform.position);

			floating = floatForce.y;

		}
	}
}