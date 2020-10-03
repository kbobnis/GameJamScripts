
using System.IO;
using UnityEditor;
using UnityEngine;

	public class KbobnisFile {
		public static void Write(string text, string path = "Assets/Resources/test.txt") {

			//Write some text to the test.txt file
			StreamWriter writer = new StreamWriter(path, true);
			writer.WriteLine(text);
			writer.Close();

			//Re-import the file to update the reference in the editor
			AssetDatabase.ImportAsset(path);
			TextAsset asset = Resources.Load(path) as TextAsset;
		}

		public static void ReadString() {
			string path = "Assets/Resources/test.txt";

			//Read the text from directly from the test.txt file
			StreamReader reader = new StreamReader(path);
			Debug.Log(reader.ReadToEnd());
			reader.Close();
		}

}