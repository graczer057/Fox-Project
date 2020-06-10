using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Pos()
    {
        anim.SetBool("Shot", true);
    }

    public void Neg()
    {
        anim.SetBool("Shot", false);
    }

   /* public void NotShoot()
    {
        anim.SetBool("Shot", false);
    }

    public IEnumerator Shot()
    {
        anim.SetBool("Shot", true);
        yield return new WaitForSeconds(2);
    }*/
}
