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


    [SerializeField] private int junpPoaint;
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
    }
    private void move()
    {
        if (Input.GetKey("d") && RightMeve)
            rect.localPosition += new Vector3(Speed, 0, 0);
        if (Input.GetKey("a") && LeftMeve)
            rect.localPosition -= new Vector3(Speed, 0, 0);

        if (Input.GetKeyDown("space") && junpPoaint > 0 && IsGround)
        {
            rb.AddForce(new Vector3(0, upForce, 0)); //上に向かって力を加える
        }
    }
}
