using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battl_Col_Enemy : MonoBehaviour
{
    [SerializeField]
    private Battl_EnemyController battl_EnemyController;        //�X�N���v�g�i�[�p

    [SerializeField]
    private Battle_PlayerController battle_PlayerController;        //�X�N���v�g�i�[�p

    private float leftMove = 0.5f, rightMove = 2.0f;    //�ǔ��˗p

    private int Damege = 1;  //�Œ�_���[�W
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

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            battl_EnemyController.Hp -= Damege;
            //�G�̍U���͂�������̃f�B�t�F���X��荂���ꍇ
            if (battl_EnemyController.DefensePoint <= battle_PlayerController.AttackPoint)
                battl_EnemyController.Hp -= battle_PlayerController.AttackPoint - battl_EnemyController.DefensePoint;
        }
    }

}
