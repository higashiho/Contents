using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [SerializeField]
    private Battle_PlayerController battle_PlayerController;    //スクリプト格納用

    [SerializeField]
    private GameObject enemy;    //スクリプト格納用

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
        
        if(enemy == null)
            findEnemy();

        statusText();
        statusSlider();

    }

    private void findEnemy()
    {
        enemy = GameObject.FindWithTag("Enemy");
    }

    //Status表示
    private void statusText()
    {
        playerAttackText.text = "Attack × " + battle_PlayerController.AttackPoint;
        playerDefenseText.text = "Defense × " + battle_PlayerController.DefensePoint;

        enemyAttackText.text = "Attack × " + enemy.GetComponent<Battl_EnemyController>().GetAttackPoint();
        enemyDefenseText.text = "Defense × " + enemy.GetComponent<Battl_EnemyController>().GetDefensePoint();
    }

    //スライダー表示
    private void statusSlider()
    {
        if (OneMaxValue)
        {
            playerHpSlider.maxValue = battle_PlayerController.Hp;
            enemyHpSlider.maxValue = enemy.GetComponent<Battl_EnemyController>().GetHpPoint();
        }
        playerHpSlider.value = battle_PlayerController.Hp;
        enemyHpSlider.value = enemy.GetComponent<Battl_EnemyController>().GetHpPoint();
        OneMaxValue = false;
    }

    public void StatusSliderUpdate()
    {
        enemyHpSlider.maxValue = enemy.GetComponent<Battl_EnemyController>().GetHpPoint();
        enemyHpSlider.value = enemy.GetComponent<Battl_EnemyController>().GetHpPoint();

    }

}
