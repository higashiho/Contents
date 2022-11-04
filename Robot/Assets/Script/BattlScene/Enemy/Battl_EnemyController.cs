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


    private int attack;                     //攻撃力
    private int defense;                    //防御力
    private int hp;                         //ヒットポイント

    // 変数取得用
    public int GetAttackPoint(){return attack;}
    public int GetDefensePoint(){return defense;}
    public int GetHpPoint(){return hp;}

    public int SetAttackPoint(int plus){return attack + plus;}
    public int SetDefensePoint(int plus){return defense + plus;}
    public int SetHpPoint(int plus){return hp + plus;}

    private const int defaultHp = 10;     // 初期Hp
    private GameObject sceneController;                     // ゲームオブジェクト代入用
    
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();

        sceneController = GameObject.FindWithTag("SceneController");

        attack = sceneController.GetComponent<Buttle_EnemyStatus>().GetAttack();
        defense = sceneController.GetComponent<Buttle_EnemyStatus>().GetDefense();
        hp = defaultHp + sceneController.GetComponent<Buttle_EnemyStatus>().GetHp();

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
        if(hp <= 0)
            Destroy(this.gameObject);
   }

    //五秒に一回向きを変える
    private IEnumerator waitJudge()
    {
        //０か１か
        Judges = Random.Range(Min, Max);
        yield return new WaitForSeconds(waitTime);
        wait = false;
    }

    private void OnDestroy()
    {
        Debug.Log("Destroy");
    }
}
