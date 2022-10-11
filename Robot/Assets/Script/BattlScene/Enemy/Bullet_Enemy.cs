using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Enemy : MonoBehaviour
{

    private int dis;    //�����i�[
    [SerializeField] private CreateDistanse createDistanse;  //�X�N���v�g�i�[�p

    private GameObject Enemy;   //�G
    private GameObject Player;  //player

    private float speed = 1.5f;   //�e��


    private RectTransform rect; //�g�����X�t�H�[���i�[�p

    private bool Left, Right;   //�E������
    private bool one = true;    //���f1��p
    // Start is called before the first frame update
    void Start()
    {

        Player = GameObject.Find("Player");
        Enemy = GameObject.Find("Enemy");

        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletSpeed();
    }
    
    //�e�̋���
    private void bulletSpeed()
    {
       dis = createDistanse.distanse(Player, Enemy);
        //�v���C���[���E����������񂾂����f
        if (one)
            if (dis < 0)
                Right = true;
            else
                Left = true;
        one = false;
        //�E�̏ꍇ
        if(Right)
            rect.localPosition += new Vector3(-speed, 0, 0);
        //���̏ꍇ
        if(Left)
            rect.localPosition += new Vector3(speed, 0, 0);
    }
   
}
