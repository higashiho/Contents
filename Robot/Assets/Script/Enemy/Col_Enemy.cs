using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyController enemycontroller;

    public int HaveCount = 0;   //持ってる個数
    private int maxHaveCount = 1;    //カウントが増える最大値
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
            if (HaveCount < maxHaveCount)
                HaveCount++;
            enemycontroller.HaveItem = true;
            
        }
        //拠点に帰ったら新しいアイテムを取りに行く
        if (other.gameObject.tag == "Home")
        {
            enemycontroller.HaveItem = false;
            if (HaveCount > 0)
                HaveCount--;
        }
    }
}
