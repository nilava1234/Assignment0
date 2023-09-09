using Godot;
using System;

public partial class Camera2D : Godot.Camera2D
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	private NodePath playerPath; // Path to the player node (set this in the editor)

	private Node2D player; // Reference to the player node
	int minX = 21;
	int minY = 29;
	int maxX = 1130;
	int maxY = 623;

	public override void _Ready()
	{
		// Get a reference to the player node using the provided path
		player = GetNode<Node2D>(playerPath);
		Vector2 playerPosition = player.GlobalPosition;
		GlobalPosition = playerPosition;
	}

	public override void _Process(double delta)
	{
		if (player != null)
		{
			Vector2 playerPosition = player.GlobalPosition;

			// Calculate the camera's half size
			Vector2 cameraHalfSize = GetViewportRect().Size / 13;

			// Calculate new camera position
			Vector2 newCameraPosition = cameraHalfSize;

			// Keep the camera within the map boundaries
			newCameraPosition.X = Mathf.Clamp(playerPosition.X, minX + cameraHalfSize.X, maxX - cameraHalfSize.X);
			newCameraPosition.Y = Mathf.Clamp(playerPosition.Y, minX + cameraHalfSize.Y, maxY - cameraHalfSize.Y);

			// Set the camera's position within the boundaries
			GlobalPosition = newCameraPosition;
		}
	}
}
