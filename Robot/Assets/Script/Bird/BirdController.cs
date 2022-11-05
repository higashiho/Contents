using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField]
    private const float speed = 10.0f;                  // 挙動スピード
    [SerializeField, HeaderAttribute("攻撃するキャラ")]
    private GameObject target;                          // 突撃するキャラ

    private Vector3 homePos;                            // 初期位置

    private bool back = false;                          // 地面に当たったか
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(target.transform.position);

        homePos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        if(!back)
            this.transform.position += transform.forward * speed * Time.deltaTime;
        else
            this.transform.position = Vector3.MoveTowards(transform.position, homePos, speed * Time.deltaTime);
    }

    public void GoBack()
    {
        transform.LookAt(homePos);
        back = true;
    }
}
