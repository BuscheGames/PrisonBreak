using Godot;

public partial class Selected : AudioStreamPlayer {
	public void OnAudioFinished() {
		QueueFree();
	}
}
