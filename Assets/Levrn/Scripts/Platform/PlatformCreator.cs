using UnityEngine;
using LevrnScripts;
using System.Collections.Generic;

public class PlatformCreator : MonoBehaviour {
	List<Square> squaresOne;
	Vector3 squareSize;
	PlatformLayout platformLayout;
	Platform platform;
	public Transform worldLocation;
	public GameObject pawn;

	// Use this for initialization
	void Start () {
		squareSize = new Vector3(0.1f, 0.01f, 0.1f);
		squaresOne = AddPlatformOneSquares();
		platformLayout = new PlatformLayout(squaresOne);
		platform = new Platform(platformLayout);
		Platform.CreatePlatform(platform, worldLocation, pawn);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	List<Square> AddPlatformOneSquares()
	{
		List<Square> squares = new List<Square>();
		squares.Add(new Square(SquareType.Start, squareSize, 0, 0));
		squares.Add(new Square(SquareType.Normal, squareSize, 1, 0));
		squares.Add(new Square(SquareType.Normal, squareSize, 2, 0));
		squares.Add(new Square(SquareType.Normal, squareSize, 1, -1));
		squares.Add(new Square(SquareType.Normal, squareSize, 1, -2));
		squares.Add(new Square(SquareType.Normal, squareSize, 2, -2));
		squares.Add(new Square(SquareType.Normal, squareSize, 3, -2));
		return squares;
	}
}
