using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battl_EnemyController : MonoBehaviour
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


    public int AttackPoint; //攻撃力
    public int DefensePoint;    //防御力
    private int startHp = 10;     // Hp初期値
    public int Hp;   //ヒットポイント

    
    private GameObject textCanvas = default;
    private TextController textController = default;      // スクリプト格納用
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        textCanvas = GameObject.Find("Text");
        textController = textCanvas.GetComponent<TextController>();
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

        destroy();
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

   // Hpがなくなった時処理
   private void destroy()
   {
        if(Hp <= 0)
        {
            AttackPoint++;
            DefensePoint++;
            Hp = startHp;
            Hp++;
            textController.statusSliderUpdate();
            Destroy(this.gameObject);

        }
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
