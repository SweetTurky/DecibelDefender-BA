using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CupOwner
{
    Player1,
    Player2
}

public class CupBehaviour : MonoBehaviour
{
    public CupOwner owner; // Assign in Inspector
    public Transform respawnPoint; // Assign in Inspector
    public ParticleSystem hitEffect; // Assign in Inspector
    public AudioClip[] soundEffects;// Assign in Inspector

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            BallBehaviour ballBehaviour = other.GetComponent<BallBehaviour>();
            if (ballBehaviour != null)
            {
                // Randomly select a sound effect from an array
                int randomIndex = Random.Range(0, soundEffects.Length);
                AudioSource.PlayClipAtPoint(soundEffects[randomIndex], transform.position);

                // Play the particle effect
                if (hitEffect != null)
                {
                    hitEffect.Play();
                }

                ballBehaviour.TeleportSphereTo(respawnPoint);

                // Remove the cup after the particle effect finishes
                Invoke(nameof(DeactivateGameObject), 1.2f);
                EarPongGameManager.Instance.CheckWinCondition(owner);
            }
        }
    }
}
