using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyai : MonoBehaviour
{
    public float dodgeSpeed = 3f;
    public float reactionTime = 0.5f;
    public int maxHealth = 3;

    private int currentHealth;
    private int deaths = 0;
    private bool canDodge = true;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") && canDodge)
        {
            StartCoroutine(Dodge());
        }
    }

    System.Collections.IEnumerator Dodge()
    {
        canDodge = false;

        // Pick a dodge direction (left or right)
        float dodgeDirection = Random.value > 0.5f ? 1f : -1f;
        float dodgeDistance = 2f;
        Vector3 dodgeTarget = transform.position + new Vector3(dodgeDirection * dodgeDistance, 0, 0);

        float elapsedTime = 0;
        Vector3 startPosition = transform.position;

        while (elapsedTime < reactionTime)
        {
            transform.position = Vector3.Lerp(startPosition, dodgeTarget, elapsedTime / reactionTime);
            elapsedTime += Time.deltaTime * dodgeSpeed;
            yield return null;
        }

        transform.position = dodgeTarget;
        canDodge = true;
    }

    public void TakeDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            LearnFromDeath();
        }
    }

    void LearnFromDeath()
    {
        deaths++;
        currentHealth = maxHealth;

        // Improve dodging skill
        dodgeSpeed += 0.5f;
        reactionTime = Mathf.Max(0.1f, reactionTime - 0.05f);

        Debug.Log("AI Died. Learning... New Dodge Speed: " + dodgeSpeed + ", Reaction Time: " + reactionTime);
        Respawn();
    }

    void Respawn()
    {
        transform.position = new Vector3(0, 0, 0);
    }
}
