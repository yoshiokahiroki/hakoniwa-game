using UnityEngine;
using System.Collections;

public class Human : MonoBehaviour {

	// 移動スピード
	public float speed = 5;
	
	void Update ()
	{
		// 右・左
		float x = Input.GetAxisRaw ("Horizontal");
	
		float y = Input.GetAxisRaw ("Vertical");;
		// 上・下
		float z = 0;
		
		// 移動する向きを求める
		Vector3 direction = new Vector3 (x, y, z).normalized;
		
		// 移動する向きとスピードを代入する
		rigidbody.velocity = direction * speed;

		Debug.Log (x);
	}
}
