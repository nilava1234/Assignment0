using Godot;
using System;

public partial class laser : RigidBody2D
{
	public float speed = 1000;

	public override void _Ready()
	{
		// Get the mouse position in the global coordinate system
		Vector2 mousePosition = GetGlobalMousePosition();

		// Calculate the direction vector towards the mouse
			Vector2 direction = (mousePosition - GlobalPosition).Normalized();

		// Set the bullet's velocity based on the direction and speed
			LinearVelocity = direction * speed;
	}
	private void _on_despawn_hitbox_body_entered(Node2D body)
	{
		// Replace with function body.
		QueueFree();
	}
	private void _on_attack_hitbox_body_entered(Node2D body)
	{
		// Replace with function body.
		if (body is target)
			{
				target enemy = (target)body;
				enemy.TakeDamage(10);
				QueueFree(); // Destroy the laser upon collision
			}
	}
}
















