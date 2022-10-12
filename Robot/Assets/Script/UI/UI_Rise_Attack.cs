using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Rise_Attack : MonoBehaviour
{
    [SerializeField]
    private float DeleteTime = 1.0f;        //消えるまでの時間
    [SerializeField]
    private float MoveRange = 1.0f;     //上に上がる距離
    [SerializeField]
    private float EndAlpha = 0;     //透明度０〜１．０

    private float TimeCnt;　     //時間を数えるTimeCount
    private TextMesh NowText;

    // Start is called before the first frame update
    void Start()
    {
        TimeCnt = 0.0f;
        Destroy(this.gameObject, DeleteTime);
        NowText = this.gameObject.GetComponent<TextMesh>();
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(Camera.main.transform);
        TimeCnt += Time.deltaTime;
                //文字の上昇距離
        this.gameObject.transform.localPosition += new Vector3(0, MoveRange / DeleteTime * Time.deltaTime, 0);
        this.gameObject.transform.Rotate(0, -180.0f, 0);
        float _alpha = 1.0f - (1.0f - EndAlpha) * (TimeCnt / DeleteTime);
        if (_alpha <= 0.0f) _alpha = 0.0f;      //透明度の調整
        NowText.color = new Color(NowText.color.r, NowText.color.g, NowText.color.b, _alpha);//文字の色
    }
}