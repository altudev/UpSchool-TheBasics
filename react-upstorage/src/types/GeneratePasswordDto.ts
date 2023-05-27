
export class GeneratePasswordDto{
    public IncludeNumbers:boolean;
    public IncludeLowercaseCharacters:boolean;
    public IncludeUppercaseCharacters:boolean;
    public IncludeSpecialCharacters:boolean;
    public Length:number;

    constructor() {
        this.IncludeNumbers = true;
        this.IncludeLowercaseCharacters = true;
        this.Length = 6;
        this.IncludeUppercaseCharacters=false;
        this.IncludeSpecialCharacters = false;
    }
}