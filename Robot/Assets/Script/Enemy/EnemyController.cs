using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    private enum items      //����̎��
    {
        Attack  =0,
        Defense = 1,
    }

    [SerializeField]
    private GameObject item;    //�擾�A�C�e��

    [SerializeField]
    private GameObject home;    //�w�n

    private UnityEngine.AI.NavMeshAgent navMeshAgent;  //�i�u���b�V���i�[�p
    private Vector3 enemyPosition;  //�����̈ʒu


    [SerializeField]
    private float speed; //���g�̃X�s�[�h

    [SerializeField] 
    private float lowSpeed; //�A�C�e���������Ă����Ԃ̎��g�̃X�s�[�h


    public bool HaveItem = false;   //�A�C�e���������Ă��邩

    private int random = 2;     //�����_���p�ő�l

    private int seekItem;   //�ǂ̃A�C�e����T����

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!HaveItem)
            move();

        if (HaveItem)
            goAway();
    }

    //����
    private void move()
    {
        //enemyPosition = transform.position;

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
            /*transform.LookAt(Item.transform);

            enemyPosition += transform.forward * speed * Time.deltaTime;

            transform.position = enemyPosition;
            */

            navMeshAgent.destination = item.transform.position;
        }
    }

    //�A�C�e�����Ƃ�����̋���
    private void goAway()
    {
        /*
        enemyPosition = transform.position;

        transform.LookAt(home.transform);

        enemyPosition += transform.forward * lowSpeed * Time.deltaTime;

        transform.position = enemyPosition;
        */
        navMeshAgent.destination = home.transform.position;
    }
    /*
    //�߂��̃I�u�W�F�N�g��T�����ē����
    private GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;   //�����p�ꎟ�ϐ�
        float nearDis = 0;  //�ł��߂��I�u�W�F�N�g�̋���
        GameObject targetObj = default;    //�I�u�W�F�N�g

        //�^�O�w�肳�ꂽ�I�u�W�F�N�g��z��Ŏ擾����
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //���g�Ǝ擾�����I�u�W�F�N�g�̋������擾
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //�I�u�W�F�N�g�̋������߂����A0�ł���΃I�u�W�F�N�g���擾
            //�ꎟ�ϐ��ɋ������i�[
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                targetObj = obs;
            }
        }
        //�ł��߂������I�u�W�F�N�g��Ԃ�
        return targetObj;
    }*/
}
