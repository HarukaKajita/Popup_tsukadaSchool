using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupStarter : MonoBehaviour {

	List<string> ansList = new List<string>();

	void Start () {
		
	}
	
	void Update () {
		if(Input.GetKeyDown("space")){
			ansList = PopupManager.AppearQuestion ((MonoBehaviour)this);

		}else if(Input.GetKeyDown("a")){
			
			print ("----------呼び出し元に返った回答Listの内容----------");
			foreach(string ans in ansList){
				print (ans);
			}
			print ("--------------------");
		}
	}
}
