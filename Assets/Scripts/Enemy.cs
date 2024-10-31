using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        if( _collider == null)
        {
            Debug.Log("Error con el collider");
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Moriste");
        }
    }
}
