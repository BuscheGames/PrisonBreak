using Godot;

public partial class Menu : CanvasLayer {

	SceneSetup _sceneSetup;

    public override void _Ready() {
		_sceneSetup = Main.Instance.GetSceneSetup("Cela 01");
    }

    public override void _Process(double delta) {
		if (Input.IsActionPressed("start")) {
			Main.Instance.PlaySelected();
			Main.Instance.InstantiateScene(_sceneSetup.scene);
		}
	}
}
