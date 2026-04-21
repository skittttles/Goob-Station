namespace Content.Server._Skittles;

[RegisterComponent]
public sealed partial class DamagePlayerOnUseComponent : Component
{
    [DataField]
    public float Damage = 50.0f;
}