using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[ExportGroup("Required Nodes")]
	[Export] AnimationPlayer _animationPlayer;

	[ExportGroup("Movement Related")]
	[Export] float _moveSpeed = 50f;

	Vector2 _direction = new();

    public override void _PhysicsProcess(double delta)
    {
        Move(_direction);

		MoveAndSlide();
    }

    public override void _UnhandledInput(InputEvent @event)
    {
		_direction = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
		if (_direction != Vector2.Zero)
		{
			_direction = _direction.Normalized();
		}
    }

	void Move(Vector2 input)
	{
		Velocity = input * _moveSpeed;
	}
}
