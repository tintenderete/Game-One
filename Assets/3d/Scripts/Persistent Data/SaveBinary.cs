using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveBinary : MonoBehaviour {
		


	public void Save(){
		Interface inter = GameObject.FindGameObjectWithTag("Player").GetComponent<Interface>();

		if (!Directory.Exists("Saves"))
			Directory.CreateDirectory("Saves");
		
		BinaryFormatter bf = new BinaryFormatter();
		FileStream saveFile = File.Create("Saves/save.binary");

		PlayerData data = new PlayerData(); 
		data.score = inter.currentScore;

		bf.Serialize (saveFile, data);
		saveFile.Close();
	}

}

[System.Serializable]
class PlayerData {

	public float score;

}
