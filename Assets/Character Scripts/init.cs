using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenuAttribute(fileName="Mood Maker", menuName="Mood Maker/Interface Demo")]
	public class Init : ScriptableObject {

		public GameObject prefab;
		public float volume;
		public string fileName;
		public float bass;
		public float mids;
		public float treble;
}
