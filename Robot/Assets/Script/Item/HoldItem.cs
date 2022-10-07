using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItem : MonoBehaviour
{
    public bool holding;    //ƒAƒCƒeƒ€‚ğ‚Á‚Ä‚¢‚é‚©
    void Start()
    {
        holding = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item")
        {
            holding = true;
        }
        if(other.gameObject.tag == "Home")
        {
            holding = false;
        }
    }
}
