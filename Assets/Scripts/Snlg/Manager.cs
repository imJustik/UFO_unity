using UnityEngine;
using System.Collections;
using System;
public class Manager : Singleton<Manager> {
	protected Manager () {} // guarantee this will be always a singleton only - can't use the constructor!
 
	public int score = 0;
	public int liveCounts = 5;
	public string quitTime = "";

}