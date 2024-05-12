using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//nuke image <a href="https://www.flaticon.com/free-icons/nuke" title="nuke icons">Nuke icons created by manshagraphics - Flaticon</a>

public class PickUp : MonoBehaviour
{
    private float timer;

    private void Awake()
    {
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10f)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PickMe(collision.gameObject.GetComponent<Character>());
        }
    }

    protected virtual void PickMe(Character characterToChange)
    {
        Destroy(gameObject);
    }
}
