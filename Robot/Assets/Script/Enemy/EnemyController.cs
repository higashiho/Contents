using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject Item;    //�擾�A�C�e��

    [SerializeField]
    private GameObject home;    //�w�n

    private Vector3 enemyPosition;  //�����̈ʒu

    [SerializeField]
    private float speed = 7.0f; //���g�̃X�s�[�h

    public bool HaveItem = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
        enemyPosition = transform.position;
        Item = serchTag(gameObject, "Item");
        transform.LookAt(Item.transform);
        enemyPosition += transform.forward * speed * Time.deltaTime;
        transform.position = enemyPosition;
    }

    //�A�C�e�����Ƃ�����̋���
    private void goAway()
    {
        enemyPosition = transform.position;
        transform.LookAt(home.transform);
        enemyPosition += transform.forward * speed * Time.deltaTime;
        transform.position = enemyPosition;
    }

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
    }
}
