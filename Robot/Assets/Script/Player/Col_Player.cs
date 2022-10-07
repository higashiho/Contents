using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Player : MonoBehaviour
{
    [SerializeField]
    private PlayerController playercontroller;
    public int HaveCount = 0;  // �����Ă��
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HaveCount > 1)
        {
            HaveCount = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �A�C�e����������狒�_�ɋA��
        if (other.gameObject.tag == "AttackItem" || other.gameObject.tag == "DefenseItem")
        {
            HaveCount++;
            playercontroller.HaveItem = true;
        }
        // ���_�ɋA������V�����A�C�e�������ɍs��
        if(other.gameObject.tag == "Home")
        {
            playercontroller.HaveItem = false;
            if (HaveCount > 0)
                HaveCount--;
        }
    }
}
