using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyController enemycontroller;

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
        if (other.gameObject.tag == "Item")
        {
            enemycontroller.HaveItem = true;
        }
        //���_�ɋA������V�����A�C�e�������ɍs��
        if (other.gameObject.tag == "Home")
        {
            enemycontroller.HaveItem = false ;
        }
    }
}
