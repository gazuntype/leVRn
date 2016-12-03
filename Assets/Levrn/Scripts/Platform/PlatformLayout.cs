using UnityEngine;
using System.Collections.Generic;

namespace LevrnScripts
{
	public class PlatformLayout
	{
		public List<Square> squares;
		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		public List<Square> Squares {
			get { return squares; }
		}

		public PlatformLayout(List<Square> squares)
		{
			this.squares = squares;
		}
	}
}
