using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f; //プレイヤーのスピード

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
            rect.localPosition += new Vector3(speed * Time.deltaTime, 0, 0);
        if (Input.GetKey("a"))
            rect.localPosition -= new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
