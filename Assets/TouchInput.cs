using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInput : MonoBehaviour {

    // フィールド部

    // テキストコンポーネント
    private Text textComponent;
    // メインカメラ
    private Camera cam;
    // スプライトのプレハブ
    public GameObject prefab;
    // スプライトのプレハブ
    public GameObject prefabDrami;

    // Use this for initialization
    void Start () {
        // テキストコンポーネントを取得
        textComponent = GetComponent<Text>();
        // メインカメラを取得
        cam = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
        // 一か所以上のタッチ情報あり？
        if (Input.touchCount > 0)
        {
            // 文字列
            string text = "";
            foreach (Touch touch in Input.touches)
            {
                // タッチ座標をスクリーン座標系からワールド座標系に変換
                Vector2 worldpos = cam.ScreenToWorldPoint(touch.position);
                // 文字列の後ろに文字を追加
                text += "touch" + touch.fingerId + ":("
                    + worldpos.x + ","
                    + worldpos.y + ")" + "\n";

                // 押した瞬間のみ
                if (touch.phase == TouchPhase.Began)
                {
                    // ０～２を超えない範囲のランダム
                    int rand = Random.Range(0, 2);
                    // 指定位置にゲームオブジェクトを生成
                    Instantiate(prefab, worldpos, Quaternion.identity);
                }

                // 文字列の後ろに文字を追加

                //// フェーズによる分岐
                //switch (touch.phase)
                //{
                //    case TouchPhase.Began://押した瞬間
                //        text = "Began";
                //        break;
                //    case TouchPhase.Moved://動いたとき
                //        text = "Moved";
                //        break;
                //    case TouchPhase.Stationary://動いてないとき
                //        text = "Stationary";
                //        break;
                //    case TouchPhase.Ended://離した瞬間
                //        text = "Ended";
                //        break;
                //    case TouchPhase.Canceled://キャンセルされた瞬間
                //        text = "Canceled";
                //        break;
                //}
            }
            textComponent.text = text;
        }
        else
        {
            textComponent.text = "No touch";
        }

        //string str1;
        // 文字列に数字を足すと、
        // 文字列に数字がつながる
        //str1 = "mojiretsu" + 1;
	}
}
