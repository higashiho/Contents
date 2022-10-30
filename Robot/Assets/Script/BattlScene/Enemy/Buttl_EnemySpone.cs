using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttl_EnemySpone : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab = default;               // エネミーprefab格納用
    private Vector3 enemyPos = new Vector3(960.0f, 780.0f, 0);   // 追加エネミー生成位置
    private GameObject enemy = default;                     // エネミーがいるかどうか判断用
    [SerializeField]
    private GameObject canvas;   //Chara格納Canvas
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        spone();
    }

    private void spone()
    {
        if(enemy == null){
            enemy = Instantiate(enemyPrefab, enemyPos, transform.rotation);
            enemy.transform.SetParent(canvas.transform);
        }
    }
}
