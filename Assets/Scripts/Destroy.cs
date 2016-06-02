using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public GameObject explosion;
    public GameObject playerExplosion;

    private GameController gameController;


    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
    
    void OnTriggerEnter(Collider other)
    {

        

        if (other.tag == "Boundary" || other.tag == "Planet") {
    		return;
    	}
    	Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            PlayerPrefs.SetInt("Score", Manager.Instance.score);
            
        }
        gameController.player.Die = true;
        gameController.gameOver = true;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
