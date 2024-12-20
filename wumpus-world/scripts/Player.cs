using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 110.0f;
	public const float JumpVelocity = -300.0f;

	private AnimatedSprite2D animatedSprite;

	public override void _Ready(){
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;


		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		if (direction.X > 0)
		{
			animatedSprite.FlipH = false;
		}
		else if (direction.X < 0)
		{
			animatedSprite.FlipH = true;
		}
		
		if(direction.X == 0){
			animatedSprite.Play("idle");
		}
		else{
			animatedSprite.Play("running");
		}

		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
