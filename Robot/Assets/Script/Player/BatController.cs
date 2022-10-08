using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController: MonoBehaviour
{
    
    void Start()
    {

    }

   
    void Update()
    {
            Attack();
      
    }
    private IEnumerator RotateX_r()   // 60ÅãâÒÇ∑
    {

        for(int i = 0; i < 3; i++)  //3âÒåJÇËï‘Ç∑
        {
            transform.Rotate(new Vector3(0, 20, 0));  // 20ÅãâÒì]
            yield return new WaitForSeconds(0.01f);Å@Å@//0.01ïb
        }
    }
    private void Attack()  // çUåÇä÷êî
    {
        if (Input.GetKey("return"))
        {
                StartCoroutine(RotateX_r());
        }
     
    }
}
