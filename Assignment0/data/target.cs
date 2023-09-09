using Godot;
using System;

public partial class target : CharacterBody2D
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	private NodePath playerPath;
	
	public Node2D player; // Reference to the player character node
	public Node2D bullet;
	public float speed = 3000.0f; // Adjust the speed of the enemy ship
	public int health = 1000;
	public override void _Ready()
	{
		player = GetNode<Node2D>(playerPath);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (player != null)
		{
			// Calculate the direction vector towards the player
			Vector2 direction = (player.GlobalPosition - GlobalPosition).Normalized();

			// Move the enemy ship towards the player
			Velocity = direction * speed * (float)delta;
			MoveAndSlide();
		}
		//GD.Print(health);
	}
	public void TakeDamage(int damage)
	{
		//GD.Print("Hit");
		health -= damage;
		if (health <= 0)
		{
			GetTree().ChangeSceneToFile("res://data/win_screen.tscn");
			QueueFree();
		}
		
	}
	
	private void die()
	{
		
	}
	private void _on_player_hitbox_body_entered(Node2D body)
	{
		GetTree().ChangeSceneToFile("res://data/death_screen.tscn");
	}
}






