using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyController enemycontroller;

    public int HoveCount = 0;   //持ってる個数
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //アイテムを取ったら拠点に帰る
        if (other.gameObject.tag == "AttackItem" || other.gameObject.tag == "DefenseItem")
        {
            HoveCount++;
            enemycontroller.HaveItem = true;
            
        }
        //拠点に帰ったら新しいアイテムを取りに行く
        if (other.gameObject.tag == "Home")
        {
            enemycontroller.HaveItem = false;
            if (HoveCount > 0)
                HoveCount--;
        }
        // playerの攻撃を受けたら...
        if(other.gameObject.tag == "Bat")
        {
            enemycontroller.b_damaged = true;  // プレイヤーの攻撃を受けた
            enemycontroller.HaveItem = false;  // アイテムを取りに行けるようにする
            if (HoveCount > 0)
                HoveCount--;
        }
    }
}
