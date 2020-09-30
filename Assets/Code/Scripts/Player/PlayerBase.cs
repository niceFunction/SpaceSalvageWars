using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public int playerId; // Maybe not needed

    // Delegate Points to UI
    public delegate void OnPlayerScore(int playerId, int scoreToAdd = 1); 
    public OnPlayerScore OnPlayerScoreHandler;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<CollectableObject>() != null)
        {
            CollectableObject _Collectable = GetComponent<CollectableObject>();
            OnPlayerScoreHandler?.Invoke(playerId, _Collectable.scorePoints); // Send event signal to UI that gets point on collision
        }
    }
}
