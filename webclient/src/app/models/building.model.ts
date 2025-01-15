export interface Building {
    id: number;
    name: string | undefined;
    address: string | undefined;
    type: string | undefined;
    garageSpaces: number;
    characterLevelRequirement: number;
    price: number;
}
