using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlash: MonoBehaviour
{
    /*[SerializeField]
    private Material flash;
    [SerializeField]
    private Material original;
    public bool b_flash;*/

    private MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        //b_flash = false;
        mesh = GetComponent<MeshRenderer>();
        mesh.material.color = mesh.material.color - new Color32(0, 0, 0, 0);
        StartCoroutine("Transparent");
    }

    // Update is called once per frame
    void Update()
    {
       // if (b_flash)
           // Flash();
    }
   /* private void Flash()
    {
        Debug.Log("UNKO");
        float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
        gameObject.GetComponent<Renderer>().material = flash;
    }*/
    public IEnumerator Transparent()
    {
       //Debug.Log("UNKO");
       /* yield return new WaitForSeconds(3.0f);

        gameObject.GetComponent<Renderer>().material = original;
        b_flash = false;*/

        for(int i = 0; i < 255; i++)
        {
            mesh.material.color = mesh.material.color - new Color32(0, 0, 0, 1);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
