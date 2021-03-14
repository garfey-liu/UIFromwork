/**
* @Author GarFey
* 20180723
*/

using System;

[Serializable]
public class SingletonTamplate<T> where T : new ()
{
	private static T _Instance;
	public static T Instance
	{
		get{
			if (_Instance == null) {
				_Instance = new T ();
			} 
			return _Instance;
		}
	}
}
