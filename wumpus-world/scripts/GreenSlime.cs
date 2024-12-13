using Godot;
using System;

public partial class GreenSlime : Node2D
{
	private RayCast2D rayCastLeft;
	private RayCast2D rayCastRight;

	private const int SPEED = 100;
	private int direction = 1;

	public override void _Ready()
	{
		rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
		rayCastRight = GetNode<RayCast2D>("RayCastRight");
	}

	public override void _Process(double delta)
	{
		if (rayCastRight.IsColliding())
		{
			direction = -1;
		}

		else if (rayCastLeft.IsColliding())
		{
			direction = 1;
		}

		Position += new Vector2(direction * SPEED * (float)delta, 0);
	}
}
