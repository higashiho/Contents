using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_PlayerController : MonoBehaviour
{
    public float Speed; //プレイヤーのスピード

    private RectTransform rect; //トランスフォーム格納用


    public bool LeftMeve, RightMeve; //左右に動けるか

    //以下ジャンプ用
    private Rigidbody2D rb; //リジッドボディ格納用
    [SerializeField] private float upForce; //上方向にかける力
    public bool IsGround; //着地しているかどうかの判定


    //public int JunpPoint;    //
    public int AttackPoint;    //攻撃力
    public int DefensePoint;    //防御力

    public int Hp = 10; //ヒットポイント



    [SerializeField]
    private GameObject bullet;  //弾のプレハブ

    private GameObject bulletPrefab;    //子オブジェクト変更用

    //private bool one = true;    //一回だけ処理

    [SerializeField]
    private GameObject canvas;   //敵

    public bool OnAttack;   //Attackできるか

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();

        rb = GetComponent<Rigidbody2D>(); //リジッドボディを取得
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
            rb.AddForce(new Vector3(0, upForce, 0)); //上に向かって力を加える
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
