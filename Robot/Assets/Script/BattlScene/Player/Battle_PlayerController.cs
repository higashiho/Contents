using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_PlayerController : MonoBehaviour
{
    public float Speed; //�v���C���[�̃X�s�[�h

    private RectTransform rect; //�g�����X�t�H�[���i�[�p


    public bool LeftMeve, RightMeve; //���E�ɓ����邩

    //�ȉ��W�����v�p
    private Rigidbody2D rb; //���W�b�h�{�f�B�i�[�p
    [SerializeField] private float upForce; //������ɂ������
    public bool IsGround; //���n���Ă��邩�ǂ����̔���


    [SerializeField] private int junpPoaint;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();

        rb = GetComponent<Rigidbody2D>(); //���W�b�h�{�f�B���擾
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void move()
    {
        if (Input.GetKey("d") && RightMeve)
            rect.localPosition += new Vector3(Speed, 0, 0);
        if (Input.GetKey("a") && LeftMeve)
            rect.localPosition -= new Vector3(Speed, 0, 0);

        if (Input.GetKeyDown("space") && junpPoaint > 0 && IsGround)
        {
            rb.AddForce(new Vector3(0, upForce, 0)); //��Ɍ������ė͂�������
        }
    }
}
