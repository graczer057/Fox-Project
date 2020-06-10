using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactEffect : MonoBehaviour
{

    public IEnumerator Destroying()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    void Update()
    {
        StartCoroutine(Destroying());
    }
}
