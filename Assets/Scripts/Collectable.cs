using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player)
        {
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            player.CoinsNumber += 10;
            Destroy(this.gameObject);
        }
    }
}