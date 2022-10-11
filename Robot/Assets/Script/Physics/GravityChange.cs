using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    [SerializeField] private Vector3 localGrabity;  //�d�͌W��
    private Rigidbody2D rb;   //���W�b�h�{�f�B�i�[�p
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        SetLocalGravity();   
    }

    //�d�͂�AddForce�ł�����
    private void SetLocalGravity()
    {
        rb.AddForce(localGrabity);
    }
}
