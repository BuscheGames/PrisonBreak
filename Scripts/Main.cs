using Godot;
using Godot.Collections;

public partial class Main : Node {

	[Export] Array<SceneSetup> scenes;

	public static Main Instance;

	CanvasLayer _currentScene;

	public override void _Ready() {
		if (Instance == null) Instance = this;
		else QueueFree();
		InstantiateScene(GetSceneSetup("Menu").scene);
	}

	public SceneSetup GetSceneSetup(string sceneName) {
		foreach(SceneSetup scene in scenes) {
			if (scene.sceneName == sceneName) return scene;
		}
		return null;
	}

	public void InstantiateScene(PackedScene scene) {
		if (_currentScene != null) _currentScene.QueueFree();
		_currentScene = (CanvasLayer) scene.Instantiate();
		AddChild(_currentScene);

	}

}
