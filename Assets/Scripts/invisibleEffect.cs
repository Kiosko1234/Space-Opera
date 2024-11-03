using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisibleEffect : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float alpha = 0.002f;

    void Start()
    {
        StartCoroutine(fadeOut());
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b,alpha);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "BulletP")
        {
            alpha = 1;
        }
    }
    IEnumerator fadeOut()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.001f);
            if (alpha > 0.002f)
            {
                alpha -= 0.001f;
            }
        }
    }
}
