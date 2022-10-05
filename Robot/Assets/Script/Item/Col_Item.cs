using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Item : MonoBehaviour
{

    private ItemController itemController;  //�J�E���g�ϐ��l�����p

    private GameObject itemControl;
    // Start is called before the first frame update
    void Start()
    {
        itemControl = GameObject.Find("ItemControl");

        itemController = itemControl.gameObject.GetComponent<ItemController>();
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
            this.gameObject.transform.parent = other.gameObject.transform;
        }
        //�G�ɓ���������q�ɂȂ��Ĉꏏ�ɓ���
        if (other.gameObject.tag == "Enemy")
        {
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
