import { ammoTypes, supportedAttachments, weaponTypes } from "../enum/weapon";

export interface weapon {
    id: number;
    name: string | undefined;
    type: weaponTypes | undefined;
    damage: number;
    rangeInMeters: number;
    magazineSize: number;
    fireRate: number;
    reloadTime: number;
    supportedAmmoTypes: ammoTypes[] | undefined;
    supportedAttachments: supportedAttachments[] | undefined;
    characterLevelRequirement: number;
    price: number;
}