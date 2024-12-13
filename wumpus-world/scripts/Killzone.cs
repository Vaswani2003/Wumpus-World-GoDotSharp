using Godot;
using System;

public partial class Killzone : Area2D
{
	private Timer _timer;
	
	public override void _Ready(){
		_timer = GetNode<Timer>("Timer");
	}
	public void _on_body_entered(Node body){
		GD.Print("YOU DIED!");
		_timer.Start();
	}
	
	public void _on_timer_timeout(){
		GetTree().ReloadCurrentScene();
	}
}
