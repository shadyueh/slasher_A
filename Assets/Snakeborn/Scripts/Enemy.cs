using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float TotalHealth;
    public float CurrentHealth;
    public float AttackDamage;
    public float MovementSpeed;

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetHit()
    {
        //anim.SetInteger("transition", 0);
        //StartCoroutine(RecoveryFromHit());
    }
    IEnumerator RecoveryFromHit()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
