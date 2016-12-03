using UnityEngine;
using System.Collections;

namespace LevrnScripts
{
	public class PawnPlayerSingleton : MonoBehaviour
	{
		public static PawnPlayerSingleton instance;
		// Use this for initialization
		void Awake()
		{
			if (!instance)
			{
				instance = this;
				DontDestroyOnLoad(gameObject);
			}
			else
			{
				Destroy(gameObject);
			}
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}

