using UnityEngine;
using System.Collections;

public class TouchPlanet : MonoBehaviour {

    public static bool pouse = false;
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
    	if (other.tag != "Player") {
    		return;
    	}

        gameController.player.Sit = true;
        gameController.gameOver = true;
        Attach(GetComponent<Rigidbody>(), other.GetComponent<Rigidbody>());

    }

    void Attach(Rigidbody planet, Rigidbody player)
    {
        player.isKinematic = false;

        player.GetComponent<HingeJoint>().connectedBody = planet;
        planet.GetComponent<HingeJoint>().connectedBody = player;

        player.GetComponent<CapsuleCollider>().enabled = false;

        player.GetComponent<PlayerController>().enabled = false;

        GameObject ufo = GameObject.Find("UFO");
        GameObject cone = GameObject.Find("Cone");

        ufo.GetComponent<Animator>().enabled = false;       
        cone.active = false;   
    }

}
