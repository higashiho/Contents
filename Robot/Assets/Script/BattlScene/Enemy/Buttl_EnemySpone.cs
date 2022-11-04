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

    [SerializeField]
    private Buttle_EnemyStatus enemyStatus;                     // スクリプト参照
    [SerializeField]
    private TextController textController;      // スクリプト参照
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

    // 新規エネミー生成
    private void spone()
    {
        if(enemy == null){
            enemyStatus.StatusUp();
            enemy = Instantiate(enemyPrefab, enemyPos, transform.rotation);
            
            enemy.transform.SetParent(canvas.transform);
            enemy = GameObject.FindWithTag("Enemy");
        }
    }
}
