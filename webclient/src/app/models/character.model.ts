export interface Character {
    id: number;
    name: string | undefined;
    experience: number;
    money: number;
    ownedBuildingIds: number[];
    ownedClothingIds: number[];
    ownedVehicleIds: number[];
    ownedWeaponIds: number[];
}