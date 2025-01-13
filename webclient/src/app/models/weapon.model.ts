export interface weapon {
    name: string | undefined;
    type: string | undefined;
    damage: number | undefined;
    rangeInMeters: number | undefined;
    magazineSize: number | undefined;
    fireRate: number | undefined;
    reloadTime: number | undefined;
    supportedAmmoTypes: string[] | undefined;
    supportedAttachments: string[] | undefined;
    characterLevelRequirement: number | undefined;
    price: number | undefined;
}