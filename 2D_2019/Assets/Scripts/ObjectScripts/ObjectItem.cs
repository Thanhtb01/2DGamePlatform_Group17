using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectItem : MonoBehaviour
{
    [SerializeField] GameObject [] dropItemPrefabs;
    [SerializeField] [Range(0f, 1f)] float chance = 1f;
    [SerializeField] GameObject hitEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(effect, 0.5f);
            if (Random.value < chance)
            {
                Transform t = Instantiate(dropItemPrefabs[Random.Range(0, dropItemPrefabs.Length)]).transform;
                t.position = transform.position;
            }
        }
    }
}
