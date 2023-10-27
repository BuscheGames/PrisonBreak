using Godot;

[GlobalClass]
public partial class SceneSetup : Resource {
	[Export] public PackedScene scene;
	[Export] public string sceneName;
}