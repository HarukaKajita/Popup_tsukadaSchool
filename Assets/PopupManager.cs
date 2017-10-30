using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour{

	static List<string> ansList = new List<string>();

	void Start () {
		Buttondata.Setup ();
	}

	public static List<string> AppearQuestion(MonoBehaviour hoge){
		//何かするとこのメソッドが呼び出されて
		//ポップアップ表示
		//最終的に回答リストを返す
		List<Button> buttons = new List<Button>();
		if (ansList.Count == 0) {
			buttons.Add(Buttondata.yesButton);
			buttons.Add(Buttondata.noButton);

			buttons [0].OnClickAsObservable ().Subscribe (_ => {ansList.Add("Yes");PopupManager.AppearQuestion(hoge);});
			buttons [1].OnClickAsObservable ().Subscribe (_ => {ansList.Add("No");OutputAnswers();});
		} else {
			buttons.Add(Buttondata.aButton);
			buttons.Add(Buttondata.bButton);
			buttons.Add(Buttondata.cButton);

			buttons [0].OnClickAsObservable ().Subscribe (_ => {ansList.Add("A");OutputAnswers();});
			buttons [1].OnClickAsObservable ().Subscribe (_ => {ansList.Add("B");OutputAnswers();});
			buttons [2].OnClickAsObservable ().Subscribe (_ => {ansList.Add("C");OutputAnswers();});
		}

		foreach(Button b in buttons){
			b.OnClickAsObservable ().Subscribe (_ => {foreach(Button button in buttons){button.gameObject.SetActive(false);}});
		}

		foreach(Button b in buttons){
			b.gameObject.SetActive (true);
		}

		hoge.StartCoroutine (WaitButtonInput(buttons));
		return ansList;
	}

	static IEnumerator WaitButtonInput(List<Button> buttons){
		var y = buttons.Select(b => b.OnClickAsObservable().First().Select(_ => b))
			.Aggregate((a, b) => a.Amb(b))
			.ToYieldInstruction();
		yield return y;
	}

	static void OutputAnswers(){
		print ("----------Result----------");
		foreach(string a in ansList){
			print (a);
		}
		print ("----------Result----------");
	}
}
