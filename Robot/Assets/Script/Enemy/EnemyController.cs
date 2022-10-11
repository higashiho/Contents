using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    private enum items      //相手の種類
    {
        Attack = 0,
        Defense = 1,
    }

    [SerializeField]
    private GameObject item;    //取得アイテム

    [SerializeField]
    private GameObject home;    //陣地

    private Vector3 enemyPosition;  //自分の位置


    [SerializeField]
    private float speed; //自身のスピード
    [SerializeField]
    private float downTime = 2f;
    [SerializeField]
    private float lowSpeed; //アイテムを持っている状態の自身のスピード

    private NavMeshAgent navMesh;   //NavMesh格納用


    public bool HaveItem = false;   //アイテムを持っているか

    private int random = 2;     //ランダム用最大値

    private int seekItem;   //どのアイテムを探すか

    public bool b_move_ok;  // 行動可能かどうか
   
    // Start is called before the first frame update
    void Start()
    {
        b_move_ok = true;   // 行動可能フラグON

        navMesh = GetComponent<NavMeshAgent>();     //navMeshを所持
    }

    // Update is called once per frame
    void Update()
    {
        if (b_move_ok)
        {
           
            if (!HaveItem)
                move();

            if (HaveItem)
                goAway();
        }

        if (!b_move_ok)
        { // エネミー行動可能フラグOFFのとき
          //StartCoroutine("Damaged");  // ダメージコルーチンに入る
            StartCoroutine("StopTime");
            //navMesh.updateRotation = true;
           // navMesh.speed = 7f;
            HaveItem = false;  // アイテムを取りに行けるようにする
            b_move_ok = true;  // エネミー行動可能フラグON
           
        }
    }

    //挙動
    private void move()
    {
        enemyPosition = transform.position;

        //Item = serchTag(gameObject, "Item");
        seekItem = Random.Range(0, random);
        if (item == null)
            switch (seekItem)
            {
                case 0: //攻撃アイテムを取りに行く
                    item = GameObject.FindWithTag("AttackItem");
                    break;
                case 1: //防御アイテムを取りに行く
                    item = GameObject.FindWithTag("DefenseItem");
                    break;
                default:
                    break;
            }

        else
        {
            /*
            transform.LookAt(Item.transform);

            enemyPosition += transform.forward * speed * Time.deltaTime;

            transform.position = enemyPosition;
               */
            navMesh.destination = item.transform.position;   //アイテムを目指して進む
            }
    }

    //アイテムをとった後の挙動
    private void goAway()
    {/*
        enemyPosition = transform.position;

        transform.LookAt(home.transform);

        enemyPosition += transform.forward * lowSpeed * Time.deltaTime;

        transform.position = enemyPosition;
        */
        navMesh.destination = home.transform.position;
    }

    private IEnumerator StopTime()
    {
        navMesh.isStopped = true;
        this.gameObject.transform.DetachChildren();  
        //item = null;
        yield return new WaitForSeconds(downTime);
        navMesh.isStopped = false ;
    } 

}