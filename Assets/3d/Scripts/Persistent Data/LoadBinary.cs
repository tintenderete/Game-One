using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine.UI;

public class LoadBinary : MonoBehaviour {
	
	private Text score;

	void Start(){
		score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
		Load ();
	}

	public void Load() {

		BinaryFormatter bf = new BinaryFormatter();
		FileStream saveFile = File.Open("Saves/save.binary", FileMode.Open);
		
		PlayerData playerData = (PlayerData)bf.Deserialize(saveFile);

		 score.text = "Score: " + playerData.score;

		saveFile.Close();
	}
}
