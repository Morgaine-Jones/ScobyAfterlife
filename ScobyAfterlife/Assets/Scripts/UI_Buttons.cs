using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Buttons : MonoBehaviour
{
	public void Restart(int sceneID)
	{
		SceneManager.LoadScene(sceneID);
	}
}
