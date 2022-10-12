using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Defence_Enemy : MonoBehaviour
{
    private Text text;      //テキスト格納用
    [SerializeField]
    private UI_Attack_Enemy ui_Attack_Enemy;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        DefenceStatus();
    }

    //EnemyのDefenceTextの表示
    private void DefenceStatus()
    {
        text.text = "Defence: " + ui_Attack_Enemy.DefaultStatus;
    }
}
