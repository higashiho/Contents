using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    private enum items      //アイテムの種類
    {
        Attack = 0,
        Defense = 1,
    }

    [SerializeField]
    private GameObject item;    //アイテム格納用

    [SerializeField]
    private GameObject home;    //拠点

    private UnityEngine.AI.NavMeshAgent navMeshAgent;  //NavMesh格納用
    private Vector3 enemyPosition;  //自身の位置


    [SerializeField]
    private float speed; //自身のスピード

    [SerializeField]
    private float lowSpeed; //アイテムを持った時のスピード


    public bool HaveItem = false;   //アイテムを持っているか

    private int random = 2;     //ランダムの最大値

    private int seekItem;   //アイテムを持っているか

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!HaveItem)
            move();

        if (HaveItem)
            goAway();
    }

    //拠点
    private void move()
    {
        //enemyPosition = transform.position;

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
            /*transform.LookAt(Item.transform);

            enemyPosition += transform.forward * speed * Time.deltaTime;

            transform.position = enemyPosition;
            */

            navMeshAgent.destination = item.transform.position;
        }
    }

    //拠点に戻る
    private void goAway()
    {
        /*
        enemyPosition = transform.position;

        transform.LookAt(home.transform);

        enemyPosition += transform.forward * lowSpeed * Time.deltaTime;

        transform.position = enemyPosition;
        */
        navMeshAgent.destination = home.transform.position;
    }
}
