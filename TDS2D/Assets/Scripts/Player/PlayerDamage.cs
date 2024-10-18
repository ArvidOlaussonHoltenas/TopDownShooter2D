using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] int playerHealth = 5;
    [SerializeField] float invincibilityTime = 2f;
    bool invincible = false;

    void DisableInvincibility()
    {
        invincible = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (invincible == true)
            {
                return;
            }
            if (playerHealth > 0)
            {
                playerHealth--;
                invincible = true;
                Invoke("DisableInvincibility", invincibilityTime);
                Debug.Log("Player health:" + playerHealth);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
