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
    private GameObject birdPrefab;                      // 鳥プレハブ


    [SerializeField, HeaderAttribute("出現座標")]
    private List<Vector3> pos = new List<Vector3>();    // 座標
    [SerializeField, HeaderAttribute("どこに出現するか")]
    private direction directions = direction.UP;        // 出現位置代入用


    [SerializeField]
    private int number;                                 // 出現位置格納ランダム用
    private int maxValue = 6;                           // for文用最大値
    private int randPos;                                // 出現座標指定ランダム用
    // Start is called before the first frame update
    void Awake()
    {
        posAdd();
    }

    // Update is called once per frame
    void Update()
    { 
    }

    private void instansBird()
    {
        posAdd();
        Instantiate(birdPrefab, pos[1], Quaternion.identity);
    }

    // posList に値を代入する
    private void posAdd()
    {
        // enumの要素数を取得
        int length = System.Enum.GetValues(typeof(direction)).Length;
        number = Random.Range(0, length);

        // numberの値にてdirectionsの要素数を変更し、posに座標を代入する
        directions += number;
        switch (directions)
        {
            case direction.UP:
                pos.Clear();
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
}
