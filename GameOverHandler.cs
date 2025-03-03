using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private RockSpawn rockSpawn;

    void Start()
    {
        rockSpawn.enabled = true;
        gameOverDisplay.gameObject.SetActive(false);
    }
    public void EndGame(){
        rockSpawn.enabled = false;
        gameOverDisplay.gameObject.SetActive(true);
    }


    public void ExitGame(){
        SceneManager.LoadScene(0);
    }

    public void PlayAgain(){
        SceneManager.LoadScene(1);
    }
}
