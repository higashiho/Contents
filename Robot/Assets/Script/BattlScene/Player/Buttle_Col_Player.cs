using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttle_Col_Player : MonoBehaviour
{
    [SerializeField]
    private Battl_AttackEnemy battl_AttackEnemy;        //スクリプト格納用

    [SerializeField]
    private Battle_PlayerController battle_PlayerController;        //スクリプト格納用


    private float speed = 2.0f; //着地時スピード
    private float junpSoeed = 1.0f; //ジャンプ時スピード
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    //TODO : 画面外に出ないようにする
    private void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.tag == "LeftWall")
        {
            battle_PlayerController.LeftMeve = false ;
        }
    if (col.gameObject.tag == "RightWall")
        {
            battle_PlayerController.RightMeve = false ;
        }

        if (col.gameObject.tag == "Graund")
        {
            battle_PlayerController.Speed = speed;
            battle_PlayerController.IsGround = true ;
        }
    }
    private void OnCollisionExit2D(Collision2D col) 
    {
        if (col.gameObject.tag == "LeftWall")
        {
            battle_PlayerController.LeftMeve = true;

        }
    if (col.gameObject.tag == "RightWall")
        {
            battle_PlayerController.RightMeve = true;

        }
        if (col.gameObject.tag == "Graund")
        {
            battle_PlayerController.Speed = junpSoeed;
            battle_PlayerController.IsGround = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "AttackPoint")
            battl_AttackEnemy.Attack();
    }
    
}
