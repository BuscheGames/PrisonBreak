using Godot;
using System;

public partial class Selected : AudioStreamPlayer {
	public void OnAudioFinished() {
		QueueFree();
	}
}
