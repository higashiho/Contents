using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController: MonoBehaviour
{
    
    void Start()
    {
        GetComponent<BoxCollider>().enabled = false;  //�o�b�g�����蔻��OFF
    }

   
    void Update()
    {
            Attack();
      
    }
    private IEnumerator RotateX_r()   // 60����
    {

        for(int i = 0; i < 3; i++)  //3��J��Ԃ�
        {
            transform.Rotate(new Vector3(0, 20, 0));  // 20����]
            yield return new WaitForSeconds(0.01f);�@�@//0.01�b
        }
    }
    private void Attack()  // �U���֐�
    {
        if (Input.GetKey("return"))
        {
                StartCoroutine(RotateX_r());
            GetComponent<BoxCollider>().enabled = true;//�o�b�g�����蔻��ON
        }
        if (Input.GetKeyUp("return"))
        {
            GetComponent<BoxCollider>().enabled = false;//�o�b�g�����蔻��OFF
        }
     
    }
}
