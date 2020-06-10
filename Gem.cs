using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public int Gems = 1;

    private void OnTriggerEnter2D(Collider2D gem)
    {
        if (gem.gameObject.CompareTag("Player"))
        {
            GameManager.instance.Score(Gems);
        }
    }
}

