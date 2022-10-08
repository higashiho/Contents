using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyController enemycontroller;

    public int HoveCount = 0;   //�����Ă��
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //�A�C�e����������狒�_�ɋA��
        if (other.gameObject.tag == "AttackItem" || other.gameObject.tag == "DefenseItem")
        {
            HoveCount++;
            enemycontroller.HaveItem = true;
            
        }
        //���_�ɋA������V�����A�C�e�������ɍs��
        if (other.gameObject.tag == "Home")
        {
            enemycontroller.HaveItem = false;
            if (HoveCount > 0)
                HoveCount--;
        }
        // player�̍U�����󂯂���...
        if(other.gameObject.tag == "Bat")
        {
            enemycontroller.b_damaged = true;  // �v���C���[�̍U�����󂯂�
            enemycontroller.HaveItem = false;  // �A�C�e�������ɍs����悤�ɂ���
            if (HoveCount > 0)
                HoveCount--;
        }
    }
}
