export interface Vehicle {
    id: number;
    name: string | undefined;
    typeOrClass: string | undefined;
    topSpeed: number;
    maxOccupants: number;
    characterLevelRequirement: number;
    price: number;
}
