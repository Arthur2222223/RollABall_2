using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private GameObject collectParticlePrefab;
   private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     // Finds the Game Manager in the Scene
    gameManager = FindAnyObjectByType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
 // Call with this object collides with a trigger
    private void OnTriggerEnter(Collider other)
{
    // Only executes if the collision was with the Player
    if (other.CompareTag("Player"))
    {
        gameManager.UpdateRemaining();

        AudioSource.PlayClipAtPoint(collectSound, transform.position);

        Instantiate(collectParticlePrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}


}