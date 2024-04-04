/*
	Title:
	
	Description:
	
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ExplosionDestroy : MonoBehaviour
{
	public float time;

	
	private void Awake()
	{
		GameObject.Destroy(this.gameObject, time);//延迟对应时间 删除游戏对象
	}

	
}

