using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SponeBird : MonoBehaviour
{
    // どこに出現するか
    private enum direction
    {
        UP = 0,
        DOWN = 1,
        LEFT = 2,
        RIGTH = 3
    }

    [SerializeField]
    private GameObject birdPrefab;                                  // 鳥プレハブ


    private const int listSize = 13;                                // リストの要素数
    [SerializeField, HeaderAttribute("出現座標")]
    private List<Vector3> pos = new List<Vector3>(listSize);        // 座標
    [SerializeField, HeaderAttribute("どこに出現するか")]
    private direction directions = direction.UP;                    // 出現位置代入用


    [SerializeField]
    private int number;                                             // 出現位置格納ランダム用
    private int maxValue = 6;                                       // for文用最大値

    private GameObject bird;                                        // 鳥がいるかどうか確認用

    private bool onCoroutine = false;                               // コルーチンに入ってるか

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    { 
        if(bird == null && !onCoroutine)
           StartCoroutine(randomSpone());
    }

    // Random判断用
    private IEnumerator randomSpone()
    {
        onCoroutine = true;
        // 三秒遅延
        float m_waitTime = 0.5f;
        yield return new WaitForSeconds(m_waitTime);

        // 最大値
        int m_greatest = 100;
        // sponeするための値
        int m_spone = 80;       

        // 0~100までの値をランダムに代入
        int m_randValue = Random.Range(0, m_greatest);   

        // 95よりも大きい場合生成
        if(m_randValue >= m_spone)
            instansBird();
            
        onCoroutine = false;
    }
    // BirdをRandomな指定位置に生成
    private void instansBird()
    {                               
        posAdd();
        
        int randPos = Random.Range(0, pos.Count);
        bird = Instantiate(birdPrefab, pos[randPos], Quaternion.identity);


    }

    // List(pos) に値を代入する
    private void posAdd()
    {
        // 列挙体要素数取得用
        int m_length = System.Enum.GetValues(typeof(direction)).Length;                                 
        number = Random.Range(0, m_length);

        // directions を初期値に戻しておく
        directions = direction.UP;
        // numberの値にてdirectionsの要素数を変更し、posに座標を代入する
        directions += number;
        switch (directions)
        {
            case direction.UP:
                for(int i = -6; i <= maxValue; i++)
                {
                    pos.Add(new Vector3((float)i, 6.0f, -16.0f));
                }
                break;
            case direction.DOWN:
                pos.Clear();
                for(int i = -6; i <= maxValue; i++)
                {
                    pos.Add(new Vector3((float)i, 6.0f, 16.0f));
                }
                break;
            case direction.LEFT:
                pos.Clear();
                for(int i = -6; i <= maxValue; i++)
                {
                    pos.Add(new Vector3(-20.0f, 6.0f, (float)i));
                }
                break;
            case direction.RIGTH:
                pos.Clear();
                for(int i = -6; i <= maxValue; i++)
                {
                    pos.Add(new Vector3(20.0f, 6.0f, (float)i));
                }
                break;
            default:
                break;
        }
        
    } 

    private void OnDestroy()
    {
        pos.Clear();

    }
}
