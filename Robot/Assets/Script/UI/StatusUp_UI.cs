using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusUp_UI : MonoBehaviour
{
    [SerializeField]
    private GameObject statusUI;//上昇するUI
    [SerializeField]
    private GameObject CoveredObject;//ステータスが上昇するオブジェクト
    [SerializeField]
    private Vector3 AdjPosition;//UI出現位置の調整用

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    private void ViewDamage(int _damage)//ステータスアップ文字の上昇
    {
        GameObject _damageObj = Instantiate(statusUI);
        _damageObj.GetComponent<TextMesh>().text = _damage.ToString();//intをstringとして扱う
        _damageObj.transform.position = CoveredObject.transform.position + AdjPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AttackItem")
        {
            ViewDamage(1);//（）内の数字が表示される
        }
        if (other.gameObject.tag == "DefenceItem")
        {
            ViewDamage(1);//（）内の数字が表示される
        }
    }
}
