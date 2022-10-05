using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject Item;    //�擾�A�C�e��

    private Vector3 EnemyPosition;  //�����̈ʒu

    private float speed = 7.0f; //���g�̃X�s�[�h


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    //����
    private void move()
    {
        EnemyPosition = transform.position;
        Item = serchtag(gameObject, "Item");
        transform.LookAt(Item.transform);
        EnemyPosition += transform.forward * speed * Time.deltaTime;
        transform.position = EnemyPosition;
    }

    //�߂��̃I�u�W�F�N�g��T�����ē����
    private GameObject serchtag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;   //�����p�ꎟ�ϐ�
        float nearDis = 0;  //�ł��߂��I�u�W�F�N�g�̋���
        GameObject targetObj = null;    //�I�u�W�F�N�g

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
    }
}
