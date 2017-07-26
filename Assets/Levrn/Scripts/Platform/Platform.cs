using UnityEngine;
using System.Collections;

namespace LevrnScripts
{
	public class Platform
	{
		public string[] commands;
		public PlatformLayout layout;
		public Transform worldLocation;
		// Use this for initialization
		void Start()
		{


		}

		// Update is called once per frame
		void Update()
		{

		}

		public string[] Commands
		{
			get { return commands; }
		}

		public PlatformLayout Layout
		{
			get { return layout; }
		}

		public Platform(string[] commands, PlatformLayout layout)
		{
			this.commands = commands;
			this.layout = layout;
		}

		public Platform(PlatformLayout layout)
		{
			this.layout = layout;
		}

		public static Platform CreatePlatform(Platform platform, Transform worldLocation, GameObject player2)
		{
			foreach (Square square in platform.layout.squares)
			{
				GameObject primitiveSquare = GameObject.CreatePrimitive(PrimitiveType.Cube);
				primitiveSquare.transform.localScale = square.squareSize;
				primitiveSquare.transform.parent = worldLocation;
				primitiveSquare.transform.localPosition = Vector3.Scale(new Vector3(square.positionx, 0, square.positiony),square.squareSize);
				primitiveSquare.transform.localPosition += new Vector3(-0.6f, 0, 0.54f);
				switch (square.type)
				{
					case SquareType.Normal:
						primitiveSquare.tag = "Normal";
						break;
					case SquareType.Start:
						primitiveSquare.tag = "Start";
						break;
					case SquareType.Mystery:
						primitiveSquare.tag = "Mystery";
						break;
				}
			}

			GameObject player = GameObject.Instantiate(player2);
			player.transform.localScale = new Vector3(platform.layout.squares[0].squareSize.x, platform.layout.squares[0].squareSize.x, platform.layout.squares[0].squareSize.x);
			player.transform.SetParent(worldLocation);
			player.transform.position = GameObject.FindGameObjectWithTag("Start").transform.position + new Vector3(0, player.GetComponentInChildren<Renderer>().bounds.extents.y, 0);
			return platform;
		}

		public static Platform CreatePlatform(Platform platform, GameObject player, Transform worldLocation)
		{
			foreach (Square square in platform.layout.squares)
			{
				GameObject primitiveSquare = GameObject.CreatePrimitive(PrimitiveType.Cube);
				primitiveSquare.AddComponent<BoxCollider>();
				primitiveSquare.transform.localScale = square.squareSize;
				primitiveSquare.transform.parent = worldLocation;
				primitiveSquare.transform.localPosition = Vector3.Scale(new Vector3(square.positionx, 0, square.positiony), square.squareSize);
				primitiveSquare.transform.localPosition += new Vector3(-0.6f, 0, 0.54f);
				switch (square.type)
				{
					case SquareType.Normal:
						primitiveSquare.tag = "Normal";
						break;
					case SquareType.Start:
						primitiveSquare.tag = "Start";
						break;
					case SquareType.Mystery:
						primitiveSquare.tag = "Mystery";
						break;
				}
			}
			GameObject.Instantiate(player);
			player.transform.localScale = new Vector3(platform.layout.squares[0].squareSize.x, platform.layout.squares[0].squareSize.x, platform.layout.squares[0].squareSize.x);
			player.transform.SetParent(worldLocation);
			player.transform.position = GameObject.FindGameObjectWithTag("Start").transform.position + new Vector3(0, player.GetComponentInChildren<Renderer>().bounds.extents.y, 0);
			return platform;
		}

		public static Platform CreatePlatform(Platform platform, GameObject cube, GameObject player, Transform worldLocation)
		{
			foreach (Square square in platform.layout.squares)
			{
				GameObject primitiveSquare = GameObject.Instantiate(cube);
				primitiveSquare.transform.parent = worldLocation;
				primitiveSquare.transform.localPosition = Vector3.Scale(new Vector3(square.positionx, 0, square.positiony), square.squareSize);
				switch (square.type)
				{
					case SquareType.Normal:
						primitiveSquare.tag = "Normal";
						break;
					case SquareType.Start:
						primitiveSquare.tag = "Start";
						break;
					case SquareType.Mystery:
						primitiveSquare.tag = "Mystery";
						break;
				}
			}
			GameObject.Instantiate(player);
			player.transform.localScale = new Vector3(platform.layout.squares[0].squareSize.x, platform.layout.squares[0].squareSize.x, platform.layout.squares[0].squareSize.x);
			player.transform.position = GameObject.FindGameObjectWithTag("Start").transform.position + new Vector3(0, player.GetComponentInChildren<Renderer>().bounds.extents.y, 0);
			return platform;
		}
	}
}
