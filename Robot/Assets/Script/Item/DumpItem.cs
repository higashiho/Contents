using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpItem : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer sprite;
    public bool b_flash;

    void Start()
    {
        b_flash = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (b_flash)
            Flash();
    }
    private void Flash()
    {
        float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
        sprite.color = new Color(1f, 1f, 1f, level);
    }
    private IEnumerator OnDamage()
    {
        yield return new WaitForSeconds(3.0f);

        sprite.color = new Color(1f, 1f, 1f, 1f);
        b_flash = false;
    }

   
}
