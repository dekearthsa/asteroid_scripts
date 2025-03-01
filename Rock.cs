using UnityEngine;

public class Rock : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 10f);
    }

    public void OnTriggerEnter(Collider other){
        PlayerHeath playerHeath = other.GetComponent<PlayerHeath>();
        if(playerHeath == null){return;}
        playerHeath.Crash();
    }
}


