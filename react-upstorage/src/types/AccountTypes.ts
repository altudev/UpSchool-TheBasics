
export type AccountGetAllDto = {
Id :string,
Title:string,
UserName:string,
Password:string,
 Url:string | null,
IsFavourite:boolean,
UserId:string,
Categories:AccountGetAllCategoryDto[],
ShowPassword:boolean | false
};

export type AccountGetAllCategoryDto = {
    Id:string,
    Name:string
}

