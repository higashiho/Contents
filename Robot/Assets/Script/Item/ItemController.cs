using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabItem;    //�p�[�c

    private int number; //index�����_���p

    private float posX = 7.0f;  //���������W�Ǘ��p
    private float posZ = 13.5f; //���������W�Ǘ��p
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        formation();
    }

    //�A�C�e�������_������
    private void formation()
    {
        number = Random.Range(0, prefabItem.Length);
        float x = Random.Range(-posX, posX);
        float z = Random.Range(-posZ, posZ);

        Vector3 pos = new Vector3(x, 0.0f, z);
        Instantiate(prefabItem[number], pos, Quaternion.identity);
    }
}
