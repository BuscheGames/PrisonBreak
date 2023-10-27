using Godot;
using Godot.Collections;

public partial class SceneManager : CanvasLayer {

	[Export] string advText;
	[Export] string optText;
	[Export] float typeTime = 0.05f;
	[Export] Dictionary<string, string> inputScenes;

	Label _advLabel;
	Label _optLabel;
	SceneSetup _sceneSetup;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		_advLabel = GetNode<Label>("AdventureText");
		_advLabel.Text = "";
		_optLabel = GetNode<Label>("OptionText");
		_optLabel.Text = "";
		TypeLabels();
	}

    public override void _UnhandledInput(InputEvent @event) {
        foreach(var item in inputScenes) {
			if (@event.IsActionPressed(item.Key)) {
				Main.Instance.PlaySelected();
				_sceneSetup = Main.Instance.GetSceneSetup(item.Value);
				if (_sceneSetup != null) Main.Instance.InstantiateScene(_sceneSetup.scene);
			}
		}
    }

    async void TypeLabels() {
		foreach(var character in advText) {
			_advLabel.Text += character;
			await ToSignal(GetTree().CreateTimer(typeTime), "timeout");
		}
		await ToSignal(GetTree().CreateTimer(.5f), "timeout");
		_optLabel.Text = optText;
	}
}
