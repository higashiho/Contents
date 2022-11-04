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
        enemy = GameObject.FindWithTag("Enemy");
        StatusText();
    }

    // Update is called once per frame
    void Update()
    {
        statusSlider();
    }

    //Status表示
    public void StatusText()
    {
        playerAttackText.text = "Attack : " + battle_PlayerController.AttackPoint;
        playerDefenseText.text = "Defense : " + battle_PlayerController.DefensePoint;

        enemyAttackText.text = "Attack : " + enemy.GetComponent<Battl_EnemyController>().GetAttackPoint();
        enemyDefenseText.text = "Defense : " + enemy.GetComponent<Battl_EnemyController>().GetDefensePoint();
    }

    //スライダー表示
    private void statusSlider()
    {
        if(enemy != null)
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
    }

    // 敵が新しく出現したらUI情報上書
    public void StatusSliderUpdate()
    {
        enemy = GameObject.FindWithTag("Enemy");
        enemyHpSlider.maxValue = enemy.GetComponent<Battl_EnemyController>().GetHpPoint();
        
        enemyAttackText.text = "Attack : " + enemy.GetComponent<Battl_EnemyController>().GetAttackPoint();
        enemyDefenseText.text = "Defense : " + enemy.GetComponent<Battl_EnemyController>().GetDefensePoint();
    }

}
