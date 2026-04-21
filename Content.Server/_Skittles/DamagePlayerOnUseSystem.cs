using Content.Shared.Damage;
using Content.Shared.Damage.Prototypes;
using Robust.Shared.Prototypes;
using Content.Shared.Interaction.Events;
using Content.Goobstation.Maths.FixedPoint;
using Content.Shared.Gibbing.Systems;

namespace Content.Server._Skittles;

public sealed class DamagePlayerOnUseSystem : EntitySystem
{
    [Dependency] private readonly DamageableSystem _damageable = default!;
    [Dependency] private readonly IPrototypeManager _proto = default!;
    //[Dependency] private readonly GibbingSystem _gibSystem = default!;

    public override void Initialize()
    {
        SubscribeLocalEvent<DamagePlayerOnUseComponent, UseInHandEvent>(OnUseInHand);
    }

    private void OnUseInHand(Entity<DamagePlayerOnUseComponent> entity, ref UseInHandEvent args)
    {
        Console.WriteLine("Damage passed in is: " + entity.Comp.Damage);
        Console.WriteLine(entity.Owner);
        //var damage = new DamageSpecifier();
        //#damage.DamageDict.Add("Blunt", entity.Comp.Damage);
        var damage = new DamageSpecifier(_proto.Index<DamageTypePrototype>("Blunt"), entity.Comp.Damage);
        _damageable.TryChangeDamage(args.User, damage);
    }
}