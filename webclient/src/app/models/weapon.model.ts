import { ammoTypes, supportedAttachments, weaponTypes } from "../enum/weapon";

export interface weapon {
    name: string | undefined;
    type: weaponTypes | undefined;
    damage: number | undefined;
    rangeInMeters: number | undefined;
    magazineSize: number | undefined;
    fireRate: number | undefined;
    reloadTime: number | undefined;
    supportedAmmoTypes: ammoTypes[] | undefined;
    supportedAttachments: supportedAttachments[] | undefined;
    characterLevelRequirement: number | undefined;
    price: number | undefined;
}