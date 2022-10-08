using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private enum items      //相手の種類
    {
        Attack  =0,
        Defense = 1,
    }

    [SerializeField]
    private GameObject Item;    //取得アイテム

    [SerializeField]
    private GameObject home;    //陣地

    private Vector3 enemyPosition;  //自分の位置


    [SerializeField]
    private float speed; //自身のスピード

    [SerializeField] 
    private float lowSpeed; //アイテムを持っている状態の自身のスピード

    [SerializeField]
    private float downCount = 2f;   // エネミーの怯みタイマー

    public bool HaveItem = false;   //アイテムを持っているか

    private int random = 2;     //ランダム用最大値

    private int seekItem;   //どのアイテムを探すか

    public bool b_damaged;  // プレイヤーの攻撃をうけたか

    // Start is called before the first frame update
    void Start()
    {
        b_damaged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!b_damaged)
        {
            if (!HaveItem)
                move();

            if (HaveItem)
                goAway();
        }
        else
            Damaged();
    }

    //挙動
    private void move()
    {
        enemyPosition = transform.position;

        //Item = serchTag(gameObject, "Item");
        seekItem = Random.Range(0, random);
        if (Item == null)
            switch (seekItem)
            {
                case 0: //攻撃アイテムを取りに行く
                    Item = GameObject.FindWithTag("AttackItem");
                    break;
                case 1: //防御アイテムを取りに行く
                    Item = GameObject.FindWithTag("DefenseItem");
                    break;
                default:
                    break;
            }

        else
        {
            transform.LookAt(Item.transform);

            enemyPosition += transform.forward * speed * Time.deltaTime;

            transform.position = enemyPosition;
        }
    }

    //アイテムをとった後の挙動
    private void goAway()
    {
        enemyPosition = transform.position;

        transform.LookAt(home.transform);

        enemyPosition += transform.forward * lowSpeed * Time.deltaTime;

        transform.position = enemyPosition;
    }

    private void Damaged()
    {
        float count = 0;
        count += Time.deltaTime;
        if(count >= downCount)
        {
            b_damaged = false;
            count = 0;
        }

    }
    /*
    //近くのオブジェクトを探索して入れる
    private GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;   //距離用一次変数
        float nearDis = 0;  //最も近いオブジェクトの距離
        GameObject targetObj = default;    //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、0であればオブジェクトを取得
            //一次変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                targetObj = obs;
            }
        }
        //最も近かったオブジェクトを返す
        return targetObj;
    }*/
}
