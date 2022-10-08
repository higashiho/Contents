using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battl_EnemyMove : MonoBehaviour
{

    [SerializeField]
    private float speed; //プレイヤーのスピード

    private RectTransform rect; //トランスフォーム格納用

    [SerializeField]
    private float random;       //ランダム値格納用

    private float Min = 0, Max = 2; //ランダムの最小値、最大値

    private float change = 1;   //右か左の変更値

    private bool wait = false;  //停止
    private float waitTime = 5.0f;  //停止時間

    [SerializeField]
    private float judges;       //右か左か
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!wait)
        {
            StartCoroutine(waitJudge());
            wait = true;
        }
        move();
    }

    private void move()
    {
        if (judges <= change)
            rect.localPosition += new Vector3(speed, 0, 0);
        else
            rect.localPosition -= new Vector3(speed, 0, 0);
    }

    //五秒に一回向きを変える
    private IEnumerator waitJudge()
    {
        //０か１か
        judges = Random.Range(Min, Max);
        yield return new WaitForSeconds(waitTime);
        wait = false;
    }
}
