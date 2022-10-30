using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Player : MonoBehaviour
{
    private int dis;    //距離格納
    [SerializeField] private CreateDistanse createDistanse;  //スクリプト格納用

    private GameObject enemy;   //敵
    private GameObject player;  //player

    private float speed = 1.5f;   //弾速


    private RectTransform rect; //トランスフォーム格納用

    private bool Left, Right;   //右か左か
    private bool one = true;    //判断1回用
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");

        rect = GetComponent<RectTransform>();   //RectTransformを取得
    }

    // Update is called once per frame
    void Update()
    {
        bulletSpeed();
    }
    //弾の挙動
    private void bulletSpeed()
    {
        if(player == null || enemy == null)
        {
            player = GameObject.FindWithTag("Player");
            enemy = GameObject.FindWithTag("Enemy");
        }
        dis = createDistanse.distanse(player, enemy);
        //プレイヤーが右か左かを一回だけ判断
        if (one)
            if (dis > 0)
                Right = true;
            else
                Left = true;
        one = false;
        //右の場合
        if (Right)
            rect.localPosition += new Vector3(-speed, 0, 0);
        //左の場合
        if (Left)
            rect.localPosition += new Vector3(speed, 0, 0);
    }
}
