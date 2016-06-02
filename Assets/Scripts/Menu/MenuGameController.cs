using UnityEngine;
using System.Collections;
using System;

public class MenuGameController : MonoBehaviour {
	public Texture2D textureGus;
	private bool isStart = false;
	public string time;
	private long temp;
	private long back;
	private long lifeToAdd;
	private System.DateTime currentDate;
	private System.DateTime oldDate;

	//private int gusCount;

	  void OnGUI() {
	  	//Debug.Log("lives count: " + gusCount);
	  	for (int i = 0; i< Manager.Instance.liveCounts; i++) {
	  		GUI.DrawTexture(new Rect(Screen.width - (Screen.width - (20+i*30)), Screen.height - (Screen.height- 20), 50,50), textureGus);
    	}
    }

	// Use this for initialization
	void Start () {
		//Debug.Log(" Manager.Instance.liveCounts: " + Manager.Instance.liveCounts);

		Manager.Instance.quitTime = PlayerPrefs.GetString("sysTime");

		Manager.Instance.liveCounts = PlayerPrefs.GetInt("gusCount");

		currentDate = System.DateTime.Now;
		////Debug.Log("Current Time:" + currentDate);

		temp = Convert.ToInt64(Manager.Instance.quitTime);  //ласт тайм. Записывается при нажатии на кнопку "Новая игра"

		//Debug.Log("LONG TIME:" + temp);
		//Debug.Log("4:20:  " + DateTime.FromBinary( 12032467847));

		 // Разница текущего времени и времени выхода. 
        // back  = Convert.ToInt64(System.DateTime.Now.ToBinary().ToString()) - temp;
		//Debug.Log("CURRENT Diffence LONG: " + back);
		//Debug.Log("TIME BACK: "+ DateTime.FromBinary(00200000000));

		oldDate = DateTime.FromBinary(temp);
		//Debug.Log("OLD TIME:" + oldDate);

		TimeSpan diff = currentDate.Subtract(oldDate);
		//Debug.Log("Diffence:" + diff);

		
			StartCoroutine(countGus());
			Debug.Log("Считаем жизни");
	}
	//28456698110 - 47.25
	//14 228 349 055  47.25/2
	// 36097403540 - 1 hours
	// 12032467847 - 20 min
	// Update is called once per frame
	void Update () {
		// Manager.Instance.liveCounts = Manager.Instance.liveCounts + 5 - back / 12032467847;
		// Debug.Log(lifeToAdd);

	}

	  IEnumerator countGus ()
    {

    	Debug.Log("loop");
    	
        while (true)
        {	
        	if (Manager.Instance.liveCounts < 5) {
        	back  = Convert.ToInt64(System.DateTime.Now.ToBinary().ToString()) - temp;
        	Debug.Log("Разница времени: " + DateTime.FromBinary(back));
        	long lifeFromTime = back / 00200000000; //Переводим количество прошедшего времени в жизни. Данной число означает 20 минут.
        	Debug.Log("lifeFromTime: " + lifeFromTime);

        	if (lifeFromTime > 5) {
        		lifeFromTime = 5;
        	}

        	long lifeToAdd = (long)Mathf.Abs(Manager.Instance.liveCounts - (long)Mathf.Abs(lifeFromTime - Manager.Instance.liveCounts));
        	//(long)Mathf.Abs(lifeFromTime - Manager.Instance.liveCounts);


        	Debug.Log("lifeToAdd: " + lifeToAdd);

        	if (lifeToAdd >= 1) {
        	Debug.Log("Жизни для добавления: " + lifeToAdd);

        	Manager.Instance.liveCounts = Manager.Instance.liveCounts + (int)lifeToAdd; //добавляем жизни
        	lifeToAdd = 0;

        	  Manager.Instance.quitTime = System.DateTime.Now.ToBinary().ToString(); //обнуляем время добавления.
			  PlayerPrefs.SetString("sysTime", Manager.Instance.quitTime);
       		 }

          
        }
          yield return new WaitForSeconds (1);
        }
    }
    //}
}
