using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Item : MonoBehaviour
{
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
        //�v���C���[�ɂȂ�����q�ɂȂ��Ĉꏏ�ɓ���
        if (other.gameObject.tag == "Player")
        {
            //TODO�F �v���C���[�̋������o������L��
        }
        //�G�ɓ���������q�ɂȂ��Ĉꏏ�ɓ���
        if (other.gameObject.tag == "Enemy")
        {
            this.gameObject.transform.parent = other.gameObject.transform;
        }
        //�ǂ��炩�̋��_�ɓ�����Ə�����
        if (other.gameObject.tag == "Home")
        {
            Destroy(this.gameObject);
        }
    }
}
