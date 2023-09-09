using Godot;
using System;

public partial class pointer : CharacterBody2D
{	
	public Node2D laser;
		public const float Speed = 300.0f;
	 private float friction = 0.1f;
	  public float bulletOffsetDistance = 20f;

	 public override void _Ready()
	{
		// Get a reference to the player node using the provided path
	}
	
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		velocity = Vector2.Zero;
		if (Input.IsActionPressed("move_left"))
			velocity.X -= 1;
		if (Input.IsActionPressed("move_right"))
			velocity.X += 1;
		if (Input.IsActionPressed("move_up"))
			velocity.Y -= 1;
		if (Input.IsActionPressed("move_down"))
			velocity.Y += 1;

		velocity = velocity.Normalized();
		if (velocity == Vector2.Zero)
		{
			Velocity = Velocity.Lerp(Vector2.Zero, friction);
		}
		else
		{
			// Apply acceleration when movement keys are pressed
			Velocity = Velocity.Lerp(velocity * Speed, friction);
		}
		MoveAndSlide();
		RotateToMouse();
		if(Input.IsActionPressed("shoot"))
			ShootLaser();
	}
	private void RotateToMouse()
	{
		Vector2 mousePos = GetGlobalMousePosition();
		Vector2 direction = (mousePos - GlobalPosition).Normalized();

		// Calculate the angle in radians between the ship's forward direction and the direction to the mouse
		float angle = Mathf.Atan2(direction.Y, direction.X);

		// Convert the angle to degrees and set the ship's rotation
		RotationDegrees =  90.0f + (angle * (180.0f / Mathf.Pi));

		
	}
	private void ShootLaser()
	{
			Node2D laserInstance = (Node2D)ResourceLoader.Load<PackedScene>("res://data/laser.tscn").Instantiate();
			
			// Set the laser's initial position (usually at the player's position)
			Vector2 mousePosition = GetGlobalMousePosition();

			// Calculate the direction from player to mouse
			Vector2 direction = (mousePosition - GlobalPosition).Normalized();

			// Calculate the spawn position with the offset
			Vector2 spawnPosition = GlobalPosition + direction * bulletOffsetDistance;

			// Create an instance of the laser

			// Set the laser's initial position
			laserInstance.GlobalPosition = spawnPosition;

			// Add the laser to the scene
			GetParent().AddChild(laserInstance);
	}
	private void _on_area_2d_body_entered(Node2D body)
	{
		// Replace with function body.
	}

}



