
export type AccountGetAllDto = {
id :string,
title:string,
userName:string,
password:string,
url:string | null,
isFavourite:boolean,
userId:string,
categories:AccountGetAllCategoryDto[],
showPassword:boolean | false
};

export type AccountGetAllCategoryDto = {
    id:string,
    name:string
}

export type AccountAddCommand = {
    title: string;
    userName: string;
    password: string;
    url?: string;
    isFavourite: boolean;
    categoryIds: string[];
}

