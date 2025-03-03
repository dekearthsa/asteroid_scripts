using UnityEngine;

public class PlayerHeath : MonoBehaviour
{
    [SerializeField] private GameOverHandler gameOverHandler;
    public void Crash(){    
        gameOverHandler.EndGame();
        gameObject.SetActive(false);
    }
}
