using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    [SerializeField] private Vector3 localGrabity;  //重力係数
    private Rigidbody rb;   //リジッドボディ格納用
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.useGravity = false;  //リジッドボディの重力をなくす
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        SetLocalGravity();   
    }

    //重力をAddForceでかける
    private void SetLocalGravity()
    {
        rb.AddForce(localGrabity, ForceMode.Acceleration);
    }
}
