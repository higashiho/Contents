using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_PlayerController : MonoBehaviour
{
    public float Speed; //プレイヤーのスピード

    private RectTransform rect; //トランスフォーム格納用

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void move()
    {
        if (Input.GetKey("d"))
            rect.localPosition += new Vector3(Speed, 0, 0);
        if (Input.GetKey("a"))
            rect.localPosition -= new Vector3(Speed, 0, 0);
    }
}
