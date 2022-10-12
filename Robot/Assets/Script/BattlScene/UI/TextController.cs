using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [SerializeField]
    private Battle_PlayerController battle_PlayerController;    //スクリプト格納用

    [SerializeField]
    private Battl_EnemyController battl_EnemyController;    //スクリプト格納用

    [SerializeField]
    private Text playerAttackText = default; //playerアタックテキスト
    [SerializeField]
    private Text playerDefenseText = default; //playerディフェンステキスト
    [SerializeField]
    private Text enemyAttackText = default; //enemyアタックテキスト
    [SerializeField]
    private Text enemyDefenseText = default; //enemyディフェンステキスト

    [SerializeField]
    private Slider playerHpSlider;    //playerHpスライダー

    [SerializeField]
    private Slider enemyHpSlider;   //EnemyHpスライダー

    public bool OneMaxValue = true;   //スライダーマックスバリューアタッチ用
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        statusText();
        statusSlider();
    }

    //Status表示
    private void statusText()
    {
        playerAttackText.text = "Attack × " + battle_PlayerController.AttackPoint;
        playerDefenseText.text = "Defense × " + battle_PlayerController.DefensePoint;

        enemyAttackText.text = "Attack × " + battl_EnemyController.AttackPoint;
        enemyDefenseText.text = "Defense × " + battl_EnemyController.DefensePoint;
    }

    //スライダー表示
    private void statusSlider()
    {
        if (OneMaxValue)
        {
            playerHpSlider.maxValue = battle_PlayerController.Hp;
            enemyHpSlider.maxValue = battl_EnemyController.Hp;
        }
        playerHpSlider.value = battle_PlayerController.Hp;
        enemyHpSlider.value = battl_EnemyController.Hp;
        OneMaxValue = false;
    }

}
