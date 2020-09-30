using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public int playerId; // Maybe not needed
    public int playerScore; // Pass to GameManager instead?

    // Delegate Points to UI
    public delegate void OnPlayerScore(int playerId, int scoreToAdd = 1); 
    public OnPlayerScore OnPlayerScoreHandler;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<CollectableObject>() != null)
        {
            CollectableObject _Collectable = GetComponent<CollectableObject>();
            playerScore += _Collectable.scorePoints;
            OnPlayerScoreHandler?.Invoke(playerId, playerScore); // Send event signal to UI that gets point on collision
        }
    }
}
