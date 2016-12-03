using UnityEngine;
using System;

namespace LevrnScripts
{
	public class Square
	{
		public SquareType type;
		public Vector3 squareSize;
		public int numberOfCoins;
		public float positionx;
		public float positiony;

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		public SquareType Type
		{
			get { return type; }
		}

		public int NumberOfCoins
		{
			get { return numberOfCoins; }
		}

		public Vector3 SquareSize
		{
			get { return squareSize; }
		}

		public float Positionx
		{
			get { return positionx; }
		}

		public float Positiony
		{
			get { return positiony; }
		}

		public Square(SquareType type, Vector3 squareSize, float positionx, float positiony)
		{
			this.type = type;
			this.squareSize = squareSize;
			this.positionx = positionx;
			this.positiony = positiony;
		}

		public Square(SquareType type, Vector3 squareSize, float positionx, float positiony, int numberOfCoins)
		{
			this.type = type;
			this.squareSize = squareSize;
			if ((type == SquareType.CoinEnd) || (type == SquareType.Transition))
			{
				this.numberOfCoins = numberOfCoins;
			}
			this.positionx = positionx;
			this.positiony = positiony;
		}
	}
}

