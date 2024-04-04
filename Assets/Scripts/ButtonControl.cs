/*
	Title:
	
	Description:
	
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
	
	public void OnClickedStartGame()
	{
		//切换游戏场景
		SceneManager.LoadScene("MainGame");
	}

	public void OnClickedReturn()
	{
		//切换到开始场景
		SceneManager.LoadScene("Start");

	}
}

