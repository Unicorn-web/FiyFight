/*
	Title:
	游戏控制单例

	Description:
	控制游戏逻辑
	
*/

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
	public GameObject[] gameObjPrefabs;//游戏对象预制体  用于创建怪物

	//怪物的创建频率
	public float createSpeed;
	float createTime;
	public Boundary boundary;//场景边界

	int score;//游戏分数
	public Text scoreTxt;//分数文本
	public GameObject gameOverPanel;//游戏结束界面
	bool isGameOver = false;

	private void Awake()
	{
		instance = this;//获取挂载的游戏对象 作为 本类唯一实例
		scoreTxt.text = "Score:" + score;
	}

	public void ScoreUpdate(int _addScore)
	{
		score += _addScore;
		scoreTxt.text = "Score:" + score;
	}

	public void GameOver()
	{
		isGameOver = true;
		gameOverPanel.SetActive(true);
	}

	private void Update()
	{
		if (Time.time - createTime > createSpeed && !isGameOver)
		{
			//创建敌人
			var obj = GameObject.Instantiate(gameObjPrefabs[ Random.Range(0,gameObjPrefabs.Length) ]);
			float rX = Random.Range(boundary.xMin, boundary.xMax);
			obj.transform.position = new Vector3(rX,1.5f,10);//随机设置位置

			createTime = Time.time;
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();//退出应用程序   （只作用于发布版本的程序）
		}
	}

	#region 单例
	GameControl() { }
	private static GameControl instance;//静态私有对象
	public static GameControl Instance//共有访问属性
	{
		get
		{
			return instance;
		}
	}
	#endregion

}

