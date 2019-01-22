using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SSDataControl : MonoBehaviour
{
	[SerializeField]
	public bool _isHost = false;
	[SerializeField]
	public string _saveDataText = "../DiceGameSaveData.txt";

	// Start is called before the first frame update
	void Start ()
	{
		if (!File.Exists (_saveDataText))
		{
			File.Create (_saveDataText);
		}
	}

	public void SaveData (int gameMode = 0, int maxMode = 1, int gameScore = 0, int maxScore = 1)
	{
		File.WriteAllText (_saveDataText, gameMode.ToString () + ',' + maxMode.ToString () + ',' + gameScore.ToString () + ',' + maxScore.ToString ());
	}

	public List<int> LoadData ()
	{
		List<int> loadData = new List<int> ();
		var loaddatas = File.ReadAllText (_saveDataText).Split (',');
		foreach (string ld in loaddatas)
		{
			loadData.Add (int.Parse (ld));
		}
		return loadData;
	}
}