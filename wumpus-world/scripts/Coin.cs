using Godot;
using System;

public partial class Coin : Area2D
{
	
	public void _ready(){
		GD.Print("Coin Init");
	}
	
	public void _on_body_entered(Node body)
	{
		GD.Print($"Coin acquired!");
		QueueFree();
	}

	
	
}
