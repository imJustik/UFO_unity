using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
   //Астеройды
    public GameObject hazard;
    public Vector3 spawnValues;

   //планета
    public GameObject planet;
    public Vector3 spawnPlanetValues;


    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public GUIText score; 


   // public float spawnPlanetWait;
    public float startPlanetWait;
    public float wavePlanetWait;

    //score
    public float startScoreWait;
    public float waitScore;

    //oil
    public float max_oil;
    public float cur_oil;
    public float drob;
    public Texture2D texture;

    //Button
    public Button button;

    //Player
    public Player player;

    //GameOver
    public bool gameOver;

    void OnGUI() {
        drob = cur_oil / max_oil;
        GUI.DrawTexture(new Rect(Screen.width - (Screen.width - 46), Screen.height - (Screen.height- 50), 50 * drob,15), texture);
    }

    void Awake()
    {
        player = new Player();
    }

    void Start ()
    {
        Manager.Instance.score = PlayerPrefs.GetInt("Score");
        updateScore();
        StartCoroutine (SpawnWaves ());
        StartCoroutine (SpawnPlanet ());
        StartCoroutine(addScore());
    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait);
            }
            yield return new WaitForSeconds (waveWait);
        }
    }

    IEnumerator SpawnPlanet ()
    {
        yield return new WaitForSeconds (startPlanetWait);
        while (true)
        {
                Vector3 spawnPlanetPosition = new Vector3 (spawnPlanetValues.x, spawnPlanetValues.y, spawnPlanetValues.z);
                Quaternion spawnPlanetRotation = Quaternion.identity;
                Instantiate (planet, spawnPlanetPosition, spawnPlanetRotation);
                yield return new WaitForSeconds (wavePlanetWait);
        }
    }

    IEnumerator addScore ()
    {
       // Debug.Log("Start socre");
        yield return new WaitForSeconds (startScoreWait);
        while (true)
        {
            //Debug.Log("update score");
                Manager.Instance.score = Manager.Instance.score + 1;
                updateScore();
                cur_oil--;
                yield return new WaitForSeconds (waitScore);
        }
    }

    void updateScore() {
        score.text = "Score:" + Manager.Instance.score;
    }

    void Update()
    {
        if (gameOver) GameOver();       
    }

    void GameOver()
    {
        //если взорвался
        if (player.Die)
        {
            //Debug.Log("Died");
        }

        //если сел на планету
        if (player.Sit)
        {
            //Debug.Log("Sit");
        }
        //общая логика
        GameObject gui = GameObject.FindWithTag("GameOver");
        Debug.Log(GameObject.FindWithTag("GameOver"));
       //  gui.active = true;
    }
}