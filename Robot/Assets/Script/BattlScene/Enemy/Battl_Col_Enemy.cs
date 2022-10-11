using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battl_Col_Enemy : MonoBehaviour
{
    [SerializeField]
    private Battl_EnemyController battl_EnemyController;        //�X�N���v�g�i�[�p


    private float speed = 1.0f; //���n���X�s�[�h
    private float junpSoeed = 0.5f; //�W�����v���X�s�[�h

    private float leftMove = 0.5f, rightMove = 2.0f;    //�ǔ��˗p
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
            battl_EnemyController.Judges = rightMove;
        }
        if (col.gameObject.tag == "RightWall")
        {
            battl_EnemyController.Judges = leftMove;
        }

        if (col.gameObject.tag == "Graund")
        {
            battl_EnemyController.Speed = speed;
            battl_EnemyController.IsGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Graund")
        {
            battl_EnemyController.Speed = junpSoeed;
            battl_EnemyController.IsGround = false;
        }
    }

}
