using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OnButtonClick : MonoBehaviour {
    

	public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }
}
