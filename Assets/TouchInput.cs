using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInput : MonoBehaviour {

    // フィールド
    private Text textComponent;

    // Use this for initialization
    void Start () {
        // テキストコンポーネントを取得
        textComponent = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        // 一か所以上のタッチ情報あり？
        if (Input.touchCount > 0)
        {
            // タッチの取得
            Touch touch = Input.GetTouch(0);

            textComponent.text =
                "touch:(" + touch.position.x + "," + touch.position.y + ")";
        }
        else
        {
            textComponent.text = "No touch";
        }
	}
}
