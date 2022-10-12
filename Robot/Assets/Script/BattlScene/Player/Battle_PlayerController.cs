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


    //public int JunpPoint;    //
    public int AttackPoint;    //�U����
    public int DefensePoint;    //�h���

    public int Hp = 10; //�q�b�g�|�C���g



    [SerializeField]
    private GameObject bullet;  //�e�̃v���n�u

    private GameObject bulletPrefab;    //�q�I�u�W�F�N�g�ύX�p

    //private bool one = true;    //��񂾂�����

    [SerializeField]
    private GameObject canvas;   //�G

    public bool OnAttack;   //Attack�ł��邩

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
        if (Input.GetKeyDown(KeyCode.Return) && AttackPoint > 0
            && OnAttack)
            attack();
    }
    private void move()
    {
        if (Input.GetKey("d") && RightMeve)
            rect.localPosition += new Vector3(Speed, 0, 0);
        if (Input.GetKey("a") && LeftMeve)
            rect.localPosition -= new Vector3(Speed, 0, 0);

        if (Input.GetKeyDown("space") && IsGround)
        {
            rb.AddForce(new Vector3(0, upForce, 0)); //��Ɍ������ė͂�������
            //JunpPoint--;
        }
    }

    private void attack()
    {
        bulletPrefab = Instantiate(bullet, transform.position, transform.rotation);
        bulletPrefab.transform.SetParent(canvas.transform);
        //AttackPoint--;
    }
}
