using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManager : MonoBehaviour
{
    public int hp;
    public bool isEnemy;
    public bool isPlayer;
    public bool isObject;
    private SpriteRenderer sr;
    public Color blinkColour = Color.red;
    public float blinkDur = 0.1f;
    private Color ogColour;
    public Animator mainCamera; 
    public string camShakeStateName = "CameraShake";
    public bool explosionImunity = false;

    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        ogColour = sr.color;
        Debug.Log(mainCamera);
    }
    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Die();
        }
    }

    public void Damage(int incomingDamage, string dmgType) //take damage
    {
        if (explosionImunity && dmgType == "explosion")
        {
            return;
        }
        hp -= incomingDamage;
        if(isEnemy || isObject)
        {
            DamageBlink();
        }
        if(isPlayer)
        {
            ScreenShake();
        }
    }

    public void Die()
    {
        if(isEnemy)
        {
            levelManager.completion++;
            Destroy(this.gameObject);
        }
    }

    private void DamageBlink()
    {
        StopAllCoroutines();
        StartCoroutine(DamageBlinkTimer());
    }
    private IEnumerator DamageBlinkTimer() //blink after getting hit
    {
        if(sr.color != blinkColour) //this is here so it doesnt get stuck on the blink colour
        {
            ogColour = sr.color;
        }
        sr.color = blinkColour;
        yield return new WaitForSeconds(blinkDur);
        sr.color = ogColour;
    }

    private void ScreenShake()
    {
        if(mainCamera != null)
        {  
            mainCamera.Play(camShakeStateName); 
        }
    }
}
