using System.Text.Json.Serialization;

namespace Database.Enums;

[Flags]
public enum WeaponAttachments
{
    None = 0,
    Scope = 1 << 0, // 1
    Silencer = 1 << 1, // 2
    ExtendedMagazine = 1 << 2, // 4
    LaserSight = 1 << 3, // 8
    Flashlight = 1 << 4, // 16
    Grip = 1 << 5, // 32
}

[Flags]
public enum AmmoTypes
{
    Normal = 0,
    ArmorPiercing = 1 << 0, // 1
    HollowPoint = 1 << 1, // 2
    Incendiary = 1 << 2, // 4
    Tracer = 1 << 3, // 8
    Explosive = 1 << 4, // 16
    FullMetalJacket = 1 << 5, // 32
}

public enum WeaponType
{
    Melee,
    Pistol,
    Shotgun,
    SMG,
    AssaultRifle,
    SniperRifle,
    LMG,
    Heavy,
    Throwable,
    Special
}