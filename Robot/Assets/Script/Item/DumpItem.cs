using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpItem : MonoBehaviour
{
    // �_�ł�����I�u�W�F�N�g�A�^�b�`�p
    [SerializeField]
    private SpriteRenderer target;
    // �_�Ŏ���
    [SerializeField]
    private float cycle = 1f;

    private float time;  // �����i�[�p
    public bool b_flash;  // �_�Ńt���O
    
    void Start()
    {
        b_flash = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (b_flash)
            flash();
    }

    private void flash() // �_�Ŋ֐�
    {
        time += Time.deltaTime;           
        var repeatval = Mathf.Repeat(time, cycle);

        var color = target.color;
        color.a = repeatval >= cycle * 0.5 ? 1 : 0;
        target.color = color;
    }
}
