using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StableAspect : MonoBehaviour {

    public enum Match
    {
        Height, // 縦合わせ
        Width   // 横合わせ
    };
    // 合わせる方向
    public Match match;

    private Camera cam;
    public float width = 1334f;
    public float height = 750f;
    public float pixelPerUnit = 100f;

    void Awake()
    {
        
        
        cam = GetComponent<Camera>();
        

        if (match == Match.Height)
        {
            float viewportW = width * Screen.height / height / Screen.width;
            // Xは余白の半分
            float viewportX = (1.0f - viewportW) / 2.0f;
            //                  X          Y  W     H                 
            cam.rect = new Rect(viewportX, 0, viewportW, 1.0f);
        }
        else
        {
            // 何倍にするのか？ ・・・Screenwidth / width
            // 縦は何ピクセルになるのか？・・・height * Screenwidth / width
            // 縦は全体の何分の一になるのか？
            float viewportH = height * Screen.width / width / Screen.height;
            // Yは余白の半分
            float viewportY = (1.0f - viewportH) / 2.0f;
            cam.rect = new Rect(0, viewportY, 1.0f, viewportH);
        }
        // 縦に合わせる
        cam.orthographicSize = height / 2f / pixelPerUnit;
    }

    //private void Update()
    //{
    //    // (縦/横）
    //    float aspectRatio = (float)Screen.height / (float)Screen.width;

    //    cam = GetComponent<Camera>();

    //    //cam.orthographicSize = height / 2f / pixelPerUnit;
    //    cam.orthographicSize = width / 2f / pixelPerUnit * aspectRatio;
    //}
}
