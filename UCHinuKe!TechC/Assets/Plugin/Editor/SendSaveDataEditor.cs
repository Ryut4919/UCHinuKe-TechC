using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (SSDataControl))]
public class SendSaveDataEditor : Editor
{
	SSDataControl _saveSendDataControl = null;

	void OnEnable ()
	{
		_saveSendDataControl = (SSDataControl) target;
	}

	public override void OnInspectorGUI ()
	{
		EditorGUILayout.LabelField ("ホストからの呼び出しを有効化");
		_saveSendDataControl._isHost = EditorGUILayout.Toggle ("有効", _saveSendDataControl._isHost);
		if (_saveSendDataControl._isHost)
			_saveSendDataControl._saveDataText = "./DiceGameSaveData.txt";
		else
			_saveSendDataControl._saveDataText = "../DiceGameSaveData.txt";
		EditorGUILayout.LabelField ("保存ファイル名", _saveSendDataControl._saveDataText);
	}
}