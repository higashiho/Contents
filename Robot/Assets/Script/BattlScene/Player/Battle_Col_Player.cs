using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Col_Player : MonoBehaviour
{
    [SerializeField]
    private Battl_AttackEnemy battl_AttackEnemy;        //�X�N���v�g�i�[�p

    [SerializeField]
    private Battle_PlayerController battle_PlayerController;        //�X�N���v�g�i�[�p


    private float speed = 2.0f; //���n���X�s�[�h
    private float junpSoeed = 1.0f; //�W�����v���X�s�[�h

    [SerializeField]
    private Battl_EnemyController battl_EnemyController;        //�X�N���v�g�i�[�p

    private int Damege = 1;  //�Œ�_���[�W
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    //TODO : ��ʊO�ɏo�Ȃ��悤�ɂ���
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
            battle_PlayerController.OnAttack = true;
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
            battle_PlayerController.OnAttack = false;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            battle_PlayerController.Hp-= Damege;
            //�G�̍U���͂�������̃f�B�t�F���X��荂���ꍇ
            if (battle_PlayerController.DefensePoint <= battl_EnemyController.AttackPoint)
                battle_PlayerController.Hp -= battl_EnemyController.AttackPoint - battle_PlayerController.DefensePoint;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "AttackPoint")
            battl_AttackEnemy.Attack();
    }
    
}
