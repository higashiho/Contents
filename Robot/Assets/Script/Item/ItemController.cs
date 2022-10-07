using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabItem;    //パーツ

    private int number; //indexランダム用

    private float posX = 7.0f;  //生成ｘ座標管理用
    private float posZ = 13.5f; //生成ｚ座標管理用
    private float posY = 0.5f;  //生成ｙ座標

    public int Count = 3;   //生成個数

    [SerializeField]
    private bool Debug = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //生成個数が０になるまで生成
        if (Count > 0)
            formation();
        if (Debug)
            countUp();
    }

    //アイテムランダム生成(最大3つ)
    private void formation()
    {
        number = Random.Range(0, prefabItem.Length);

        float x = Random.Range(-posX, posX);
        float z = Random.Range(-posZ, posZ);

        Vector3 pos = new Vector3(x, posY, z);
        Instantiate(prefabItem[number], pos, Quaternion.identity);

        Count--;
    }

    private void countUp()
    {
        if (Input.GetKeyDown("g"))
        {
            Count++;
        }
    }
}
