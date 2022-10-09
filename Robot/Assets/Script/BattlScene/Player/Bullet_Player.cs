using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Player : MonoBehaviour
{
    private int dis;    //ฃi[
    [SerializeField] private CreateDistanse createDistanse;  //XNvgi[p

    private GameObject Enemy;   //G
    private GameObject Player;  //player

    private float speed = 1.5f;   //eฌ


    private RectTransform rect; //gXtH[i[p

    private bool Left, Right;   //Eฉถฉ
    private bool one = true;    //ปf1๑p
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Enemy = GameObject.Find("Enemy");

        rect = GetComponent<RectTransform>();   //RectTransform๐ๆพ
    }

    // Update is called once per frame
    void Update()
    {
        bulletSpeed();
    }
    //eฬฎ
    private void bulletSpeed()
    {
        dis = createDistanse.distanse(Player, Enemy);
        //vC[ชEฉถฉ๐๊๑พฏปf
        if (one)
            if (dis > 0)
                Right = true;
            else
                Left = true;
        one = false;
        //Eฬ๊
        if (Right)
            rect.localPosition += new Vector3(-speed, 0, 0);
        //ถฬ๊
        if (Left)
            rect.localPosition += new Vector3(speed, 0, 0);
    }
}
