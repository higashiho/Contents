using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyController enemycontroller;

    public int HaveCount = 0;   //�����Ă��
    private int maxHaveCount = 1;    //�J�E���g��������ő�l
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
            if (HaveCount < maxHaveCount)
                HaveCount++;
            enemycontroller.HaveItem = true;
            
        }
        //���_�ɋA������V�����A�C�e�������ɍs��
        if (other.gameObject.tag == "Home")
        {
            enemycontroller.HaveItem = false;
            if (HaveCount > 0)
                HaveCount--;
        }
    }
}
