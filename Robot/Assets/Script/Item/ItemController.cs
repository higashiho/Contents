using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabItem;    //パーツ

    private int number; //indexランダム用

    private float posX = 7.0f;  //生成ｘ座標管理用
    private float posZ = 13.5f; //生成ｙ座標管理用
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        formation();
    }

    //アイテムランダム生成
    private void formation()
    {
        number = Random.Range(0, prefabItem.Length);
        float x = Random.Range(-posX, posX);
        float z = Random.Range(-posZ, posZ);

        Vector3 pos = new Vector3(x, 0.0f, z);
        Instantiate(prefabItem[number], pos, Quaternion.identity);
    }
}
