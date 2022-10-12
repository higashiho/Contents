using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattlGameOver : MonoBehaviour
{

    [SerializeField]
    private Battle_PlayerController battle_PlayerController;        //スクリプト格納用

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameOvber(); 
    }
    private void gameOvber()
    {
        if (battle_PlayerController.Hp <= 0)
        {
            SceneManager.LoadScene("GameClearScene");
        }
    }
}
