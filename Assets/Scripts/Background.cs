/*
	Title: 背景滚动
	
	Description:
	通过材质属性偏移 实现基本滚动效果
	
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
	MeshRenderer meshRD;
	public float speed;

	private void Start()
	{
		meshRD = GetComponent<MeshRenderer>();
	}
	private void Update()
	{
		//通过材质属性偏移 实现基本滚动效果
		meshRD.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
	}

	//出界删除对象
	private void OnTriggerExit(Collider other)
	{
		GameObject.Destroy(other.gameObject);
	}


}

