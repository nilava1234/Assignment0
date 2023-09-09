using Godot;
using System;

public partial class control : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void _on_play_pressed()
	{
		// Replace with function body.
		GetTree().ChangeSceneToFile("res://data/background.tscn");
	}
	private void _on_quit_pressed()
	{
		// Replace with function body.
		GetTree().Quit();
	}
	
}






