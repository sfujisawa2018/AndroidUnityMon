using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    // Rigidbody2Dコンポーネント
    private Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
        // アタッチされたRigidbody2Dコンポーネントを取得
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        // 水平方向入力を取得
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        // 垂直方向入力を取得
        float y = CrossPlatformInputManager.GetAxis("Vertical");
        // 位置を動かす
        //transform.position += new Vector3(x, y, 0) * 0.03f;
        rigidbody.AddForce(new Vector2(x, y) * 2.0f);

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            rigidbody.gravityScale = 1.0f;

            rigidbody.AddForce(new Vector2(0, 500));
        }

        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            //rigidbody.gravityScale = 1.0f;

            rigidbody.AddForce(new Vector2(200, 0));
        }

    }
}
