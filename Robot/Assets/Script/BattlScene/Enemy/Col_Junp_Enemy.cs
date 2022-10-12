using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Junp_Enemy : MonoBehaviour
{
    [SerializeField]
    private Battl_EnemyController battl_EnemyController;    //スクリプト格納用
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //プレイヤーの球が当たったらジャンプする
        if (other.gameObject.tag == "PlayerBullet")
        {
            battl_EnemyController.Junp();
            battl_EnemyController.JunpPoint--;
        }
    }
}
