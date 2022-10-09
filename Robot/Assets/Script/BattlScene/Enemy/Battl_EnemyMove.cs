using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battl_EnemyMove : MonoBehaviour
{

    public float Speed; //プレイヤーのスピード

    private RectTransform rect; //トランスフォーム格納用

    [SerializeField]
    private float random;       //ランダム値格納用

    private float Min = 0, Max = 2; //ランダムの最小値、最大値

    private float change = 1;   //右か左の変更値

    private bool wait = false;  //停止
    private float waitTime = 5.0f;  //停止時間
    public float Judges;       //右か左か


    private Rigidbody2D rb; //リジッドボディを取得するための変数
    [SerializeField]
    private float upForce; //上方向にかける力
    public bool IsGround; //着地しているかどうかの判定
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        rb = GetComponent<Rigidbody2D>(); //リジッドボディを取得
    }

    // Update is called once per frame
    void Update()
    {
        if (!wait)
        {
            StartCoroutine(waitJudge());
            wait = true;
        }
        move();
    }

    private void move()
    {
        //右
        if (Judges >= change)
            rect.localPosition += new Vector3(Speed, 0, 0);
        //左
        else
            rect.localPosition -= new Vector3(Speed, 0, 0);
    }

    public void junp()
    {
        rb.AddForce(new Vector3(0, upForce, 0)); //上に向かって力を加える
    }

    //五秒に一回向きを変える
    private IEnumerator waitJudge()
    {
        //０か１か
        Judges = Random.Range(Min, Max);
        yield return new WaitForSeconds(waitTime);
        wait = false;
    }
}
