using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Boom }

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemType itemType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Use(collision.gameObject);
            
            Destroy(gameObject);
        }
    }

    public void Use(GameObject player)
    {
        switch (itemType)
        {
            case ItemType.Boom:
                player.GetComponent<Explosion>().BoomCount++;
                break;
        }
    }
}
