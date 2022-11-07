using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    private enum items      //　アイテムの種類
    {
        Attack = 0,
        Defense = 1,
    }

    [SerializeField]
    private GameObject item;    //取りに行くアイテム

    [SerializeField]
    private GameObject home;    //持ち帰る場所

    private Vector3 enemyPosition;  //自身の位置


    [SerializeField]
    private float speed; //挙動スピード
 
    [SerializeField]
    private float lowSpeed; //アイテムを持った場合のスピード

    [SerializeField]
    private float downTime = 2f;  // 動けなくなる時間

    private NavMeshAgent navMesh;   //NavMesh取得用


    public bool HaveItem = false;   //アイテムを持っているか

    private int seekItem;   // アイテムランダム用

    public bool b_move_ok;  // 動けるかどうか

    [SerializeField]
    private GameObject marking;
    private Col_Marking colMarking;
    private bool onDamage = false;          // ダメージを受けたか
    
    private bool onHeel = true;             // ヒールに入ったか
   
    // Start is called before the first frame update
    void Start()
    {
        b_move_ok = true;   

        navMesh = GetComponent<NavMeshAgent>();     
    }

    // Update is called once per frame
    void Update()
    {
        if(marking != null)
            if(colMarking.GetDamage())
                onDamage = colMarking.GetDamage();
        

        if(onDamage)
        {
            if(onHeel)
            {
                float waitTime = 3.0f;
                onHeel = false;
                Invoke("heelDamage", waitTime); 
            }
            return;
        }

        if (b_move_ok)      
        {
           
            if (!HaveItem)  
                move();     

            if (HaveItem)  
                goAway();   
        }

        if (!b_move_ok)     
        {
            StartCoroutine("StopTime");
        }
    }
    // ダメージ用変数初期化
     private void heelDamage()
    {
        onDamage = false;
        onHeel = true;
    }

    // Markingオブジェクト取得
    public void FindMarking(GameObject markingObj)
    {
        marking = markingObj;
        colMarking = marking.GetComponent<Col_Marking>();
    }
    //挙動
    private void move()
    {
        int m_random = 2;
        enemyPosition = transform.position;

        //Item = serchTag(gameObject, "Item");
        seekItem = Random.Range(0, m_random);
        if (item == null)
            switch (seekItem)
            {
                case 0: //Attackアイテムを目指す
                    item = GameObject.FindWithTag("AttackItem");
                    break;
                case 1: //Defenseアイテムを目指す
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
            navMesh.destination = item.transform.position;   
            }
    }

    //  アイテムを取得したら家に帰る
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
        yield return new WaitForSeconds(downTime);
        this.gameObject.transform.DetachChildren();
        HaveItem = false;  
        b_move_ok = true;  
        navMesh.isStopped = false;
    }

   
}