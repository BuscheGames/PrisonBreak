using Godot;
using Godot.Collections;

public partial class SceneManager : CanvasLayer {

	[Export] string advText;
	[Export] string optText;
	[Export] Dictionary<string, string> inputScenes;

	Label _advLabel;
	Label _optLabel;
	SceneSetup _sceneSetup;

	public override void _Ready() {
		_advLabel = GetNode<Label>("AdventureText");
		_advLabel.Text = "";
		_optLabel = GetNode<Label>("OptionText");
		_optLabel.Text = "";
		TypeLabels();
	}

    public override void _UnhandledInput(InputEvent @event) {
        foreach(var item in inputScenes) {
			if (@event.IsActionPressed(item.Key) && item.Key == "quit") {
				GetTree().Quit();
			}
			else if (@event.IsActionPressed(item.Key)) {
				Main.Instance.PlaySelected();
				_sceneSetup = Main.Instance.GetSceneSetup(item.Value);
				if (_sceneSetup != null) Main.Instance.InstantiateScene(_sceneSetup.scene);
			}
		}
    }

    async void TypeLabels() {
		foreach(var character in advText) {
			_advLabel.Text += character;
			await ToSignal(GetTree().CreateTimer(Main.Instance.typingDuration), "timeout");
		}
		await ToSignal(GetTree().CreateTimer(.3f), "timeout");
		_optLabel.Text = optText;
	}
}
