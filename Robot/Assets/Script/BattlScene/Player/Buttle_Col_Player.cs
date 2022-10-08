using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttle_Col_Player : MonoBehaviour
{
    [SerializeField]
    private Battl_AttackEnemy battl_AttackEnemy;        //スクリプト格納用

    [SerializeField]
    private Battle_PlayerController battle_PlayerController;        //スクリプト格納用


    private float Return = 1;   //壁に当たった時
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.tag == "LeftWall")
        {
            battle_PlayerController.Speed *= Return;
        }
    }
    private void OnCollisionExit2D(Collision2D col) 
    {
        if (col.gameObject.tag == "LeftWall")
        {
            battle_PlayerController.Speed *= Return;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "AttackPoint")
            battl_AttackEnemy.Attack();
    }
    
}
