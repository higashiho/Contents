using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Item : MonoBehaviour
{

    private ItemController itemController;  //�J�E���g�ϐ��l�����p

    private GameObject itemControl;        // Item�����Ǘ��p

    private Col_Enemy col_Enemy;           // Item���������p
    private Col_Player col_Player;         // Item���������p

    private GameObject Enemy;              // Col_Enemy�擾�p
    private GameObject Player;             // Col_Player�擾�p
    // Start is called before the first frame update
    void Start()
    {
        itemControl = GameObject.Find("ItemControl");

        Enemy = GameObject.Find("Enemy");
        Player = GameObject.Find("Player");

        itemController = itemControl.gameObject.GetComponent<ItemController>();

        col_Enemy = Enemy.gameObject.GetComponent<Col_Enemy>();
        col_Player = Player.gameObject.GetComponent<Col_Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //�v���C���[�ɂȂ�����q�ɂȂ��Ĉꏏ�ɓ���
        if (other.gameObject.tag == "Player")
        { 
            if(col_Player.HaveCount == 1)
            this.gameObject.transform.parent = other.gameObject.transform;
        }
        //�G�ɓ���������q�ɂȂ��Ĉꏏ�ɓ���
        if (other.gameObject.tag == "Enemy")
        {
            if (col_Enemy.HoveCount == 0)
                this.gameObject.transform.parent = other.gameObject.transform;
        }
        //�ǂ��炩�̋��_�ɓ�����Ə�����
        if (other.gameObject.tag == "Home")
        {
            itemController.Count++;

            Destroy(this.gameObject);
        }
    }
}
