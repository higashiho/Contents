using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController: MonoBehaviour
{
    
    void Start()
    {
        GetComponent<BoxCollider>().enabled = false;  //バット当たり判定OFF
    }

   
    void Update()
    {
            Attack();
      
    }
    private IEnumerator RotateX_r()   // 60°回す
    {

        for(int i = 0; i < 3; i++)  //3回繰り返す
        {
            transform.Rotate(new Vector3(0, 20, 0));  // 20°回転
            yield return new WaitForSeconds(0.01f);　　//0.01秒
        }
    }
    private void Attack()  // 攻撃関数
    {
        if (Input.GetKey("return"))
        {
                StartCoroutine(RotateX_r());
            GetComponent<BoxCollider>().enabled = true;//バット当たり判定ON
        }
        if (Input.GetKeyUp("return"))
        {
            GetComponent<BoxCollider>().enabled = false;//バット当たり判定OFF
        }
     
    }
}
