using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyController enemycontroller;

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
        if (other.gameObject.tag == "Item")
        {
            enemycontroller.HaveItem = true;
        }
        //拠点に帰ったら新しいアイテムを取りに行く
        if (other.gameObject.tag == "Home")
        {
            enemycontroller.HaveItem = false ;
        }
    }
}
