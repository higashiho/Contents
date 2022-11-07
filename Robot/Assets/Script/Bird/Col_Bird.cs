using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Bird : MonoBehaviour
{
    private bool onDamage = false;                  // ダメージが入るか

    public bool GetOnDamage() {return onDamage;}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        // 地面に当たったら帰る
        if(col.gameObject.tag == "Graund")
        {
            onDamage = true;
            this.GetComponent<BirdController>().GoBack();
        }
    }
}
