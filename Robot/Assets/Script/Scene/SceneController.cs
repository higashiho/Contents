using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private FadeController fadeController;
    [SerializeField] private GameObject FadeObject;
    public bool SceneMove = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();     // Escキーが押されたらアプリ終了
        }

        if (SceneMove)
        {
            if (Input.GetKeyDown(KeyCode.Return))   // Enterキーが押されたとき
            {
                if (SceneManager.GetActiveScene().name == "GameClearScene")     // 現在のシーンがGameClearSceneなら
                {
                    SceneMove = false;
                    fadeController.fadeOutStart(0, 0, 0, 0, "TittleScene");    // フェードアウトしてTittleSceneを読み込む
                }
                if (SceneManager.GetActiveScene().name == "GameOverScene")     // 現在のシーンがGameOverSceneなら
                {
                    SceneMove = false;
                    fadeController.fadeOutStart(0, 0, 0, 0, "TittleScene");    // フェードアウトしてTittleSceneを読み込む
                }
                if (SceneManager.GetActiveScene().name == "TittleScene")    // 現在のシーンがTittleSceneなら
                {
                    SceneMove = false;
                    fadeController.fadeOutStart(0, 0, 0, 0, "MainScene");    // フェードアウトしてMainSceneを読み込む
                }
            }
        }
    }
}
