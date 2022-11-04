using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battl_Col_Enemy : MonoBehaviour
{
    [SerializeField]
    private Battl_EnemyController battl_EnemyController;        //スクリプト格納用


    private GameObject player = default;
    [SerializeField]
    private Battle_PlayerController battle_PlayerController;        //スクリプト格納用

    private float leftMove = 0.5f, rightMove = 2.0f;    //壁反射用

    private int Damege = 1;  //固定ダメージ
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        battle_PlayerController = player.GetComponent<Battle_PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "LeftWall")
        {
            battl_EnemyController.Judges = rightMove;
        }
        if (col.gameObject.tag == "RightWall")
        {
            battl_EnemyController.Judges = leftMove;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            battl_EnemyController.SetHpPoint(-Damege);
            //敵の攻撃力がこちらのディフェンスより高い場合
            if (battl_EnemyController.GetDefensePoint() < battle_PlayerController.AttackPoint)
                battl_EnemyController.SetHpPoint(battl_EnemyController.GetDefensePoint() - battle_PlayerController.AttackPoint);
        }
    }

}
