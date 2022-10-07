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
    private float posY = 0.5f;  //���������W

    public int Count = 3;   //������

    [SerializeField]
    private bool Debug = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���������O�ɂȂ�܂Ő���
        if (Count > 0)
            formation();
        if (Debug)
            countUp();
    }

    //�A�C�e�������_������(�ő�3��)
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
