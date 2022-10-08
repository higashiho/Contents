using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    private enum items      //����̎��
    {
        Attack = 0,
        Defense = 1,
    }

    [SerializeField]
    private GameObject item;    //�擾�A�C�e��

    [SerializeField]
    private GameObject home;    //�w�n

    private Vector3 enemyPosition;  //�����̈ʒu


    [SerializeField]
    private float speed; //���g�̃X�s�[�h
    [SerializeField]
    private float downTime = 2f;
    [SerializeField]
    private float lowSpeed; //�A�C�e���������Ă����Ԃ̎��g�̃X�s�[�h

    private NavMeshAgent navMesh;   //NavMesh�i�[�p


    public bool HaveItem = false;   //�A�C�e���������Ă��邩

    private int random = 2;     //�����_���p�ő�l

    private int seekItem;   //�ǂ̃A�C�e����T����

    public bool b_move_ok;  // �s���\���ǂ���
   
    // Start is called before the first frame update
    void Start()
    {
        b_move_ok = true;   // �s���\�t���OON

        navMesh = GetComponent<NavMeshAgent>();     //navMesh������
    }

    // Update is called once per frame
    void Update()
    {
        if (b_move_ok)
        {
           
            if (!HaveItem)
                move();

            if (HaveItem)
                goAway();
        }

        if (!b_move_ok)
        { // �G�l�~�[�s���\�t���OOFF�̂Ƃ�
          //StartCoroutine("Damaged");  // �_���[�W�R���[�`���ɓ���
            StartCoroutine("StopTime");
            //navMesh.updateRotation = true;
           // navMesh.speed = 7f;
            HaveItem = false;  // �A�C�e�������ɍs����悤�ɂ���
            b_move_ok = true;  // �G�l�~�[�s���\�t���OON
           
        }
    }

    //����
    private void move()
    {
        enemyPosition = transform.position;

        //Item = serchTag(gameObject, "Item");
        seekItem = Random.Range(0, random);
        if (item == null)
            switch (seekItem)
            {
                case 0: //�U���A�C�e�������ɍs��
                    item = GameObject.FindWithTag("AttackItem");
                    break;
                case 1: //�h��A�C�e�������ɍs��
                    item = GameObject.FindWithTag("DefenseItem");
                    break;
                default:
                    break;
            }

        else
        {
            /*
            transform.LookAt(Item.transform);

            enemyPosition += transform.forward * speed * Time.deltaTime;

            transform.position = enemyPosition;
               */
            navMesh.destination = item.transform.position;   //�A�C�e����ڎw���Đi��
            }
    }

    //�A�C�e�����Ƃ�����̋���
    private void goAway()
    {/*
        enemyPosition = transform.position;

        transform.LookAt(home.transform);

        enemyPosition += transform.forward * lowSpeed * Time.deltaTime;

        transform.position = enemyPosition;
        */
        navMesh.destination = home.transform.position;
    }

    private IEnumerator StopTime()
    {
        navMesh.isStopped = true;
        this.gameObject.transform.DetachChildren();  
        //item = null;
        yield return new WaitForSeconds(downTime);
        navMesh.isStopped = false ;
    } 

}