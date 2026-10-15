// VERSION 1.1: Add a behavior so that the Collectible rotates slowly about the y-axis.

using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    // Sound clip played when the player collects this object
    [SerializeField] private AudioClip collectSound;
    // Particle effect prefab instantiated when the object is collected
    [SerializeField] private GameObject collectParticlePrefab;
    // Speed of rotation around the y-axis in degrees per second
    [SerializeField] private float rotationSpeed = 50f;

    // Reference to the GameManager to update the remaining collectible count
    private GameManager gameManager;

    void Start()
    {
        // Find and store the reference to the GameManager in the scene
        gameManager = FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        // Call the helper method to perform rotation logic
        RotateCollectible();
    }

    // Rotates the game object around its y-axis based on rotationSpeed and deltaTime
    private void RotateCollectible()
    {
        // Rotate around the y-axis smoothly using degrees per second
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is tagged as the Player
        if (other.CompareTag("Player"))
        {
            // Notify the manager to decrement remaining items
            gameManager.UpdateRemaining();
            // Play collection sound effect at current position
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            // Spawn collection particle effect at current position
            Instantiate(collectParticlePrefab, transform.position, Quaternion.identity);
            // Destroy this collectible GameObject
            Destroy(gameObject);
        }
    }
}