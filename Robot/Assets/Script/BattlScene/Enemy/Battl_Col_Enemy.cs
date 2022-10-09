using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battl_Col_Enemy : MonoBehaviour
{
    [SerializeField]
    private Battl_EnemyMove battl_EnemyMove;        //スクリプト格納用


    private float speed = 1.0f; //着地時スピード
    private float junpSoeed = 0.5f; //ジャンプ時スピード

    private float leftMove = 0.5f, rightMove = 2.0f;    //壁反射用
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
            battl_EnemyMove.Judges = rightMove;
        }
        if (col.gameObject.tag == "RightWall")
        {
            battl_EnemyMove.Judges = leftMove;
        }

        if (col.gameObject.tag == "Graund")
        {
            battl_EnemyMove.Speed = speed;
            battl_EnemyMove.IsGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Graund")
        {
            battl_EnemyMove.Speed = junpSoeed;
            battl_EnemyMove.IsGround = false;
        }
    }

}
