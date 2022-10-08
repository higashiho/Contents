using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpItem : MonoBehaviour
{
    // 点滅させるオブジェクトアタッチ用
    [SerializeField]
    private SpriteRenderer target;
    // 点滅周期
    [SerializeField]
    private float cycle = 1f;

    private float time;  // 時刻格納用
    public bool b_flash;  // 点滅フラグ
    
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

    private void flash() // 点滅関数
    {
        time += Time.deltaTime;           
        var repeatval = Mathf.Repeat(time, cycle);

        var color = target.color;
        color.a = repeatval >= cycle * 0.5 ? 1 : 0;
        target.color = color;
    }
}
