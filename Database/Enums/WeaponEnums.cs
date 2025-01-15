namespace Database.Enums;

[Flags]
public enum WeaponAttachments
{
    None = 1 << 0, // 1
    Scope = 1 << 1, // 2
    Silencer = 1 << 2, // 4
    ExtendedMagazine = 1 << 3, // 8
    LaserSight = 1 << 4, // 16
    Flashlight = 1 << 5, // 32
    Grip = 1 << 6, // 64
}

[Flags]
public enum AmmoTypes
{
    Normal = 1 << 0, // 1
    ArmorPiercing = 1 << 1, // 2
    HollowPoint = 1 << 2, // 4
    Incendiary = 1 << 3, // 8
    Tracer = 1 << 4, // 16
    Explosive = 1 << 5, // 32
    FullMetalJacket = 1 << 6, // 64
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