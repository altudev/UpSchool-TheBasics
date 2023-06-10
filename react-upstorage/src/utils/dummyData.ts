import {AccountGetAllDto} from "../types/AccountTypes.ts";

export const dummyAccounts:AccountGetAllDto[] = [
    {
        id:"12345",
        title:"Yemek Sepeti",
        url:"www.yemeksepeti.com",
        isFavourite:false,
        userId:"iamthebestdeveloper",
        userName:"alpertunga",
        password:"123alper132",
        categories:[],
        showPassword:false,
    },
    {
        id:"123456",
        title:"Getir",
        url:"www.getir.com",
        isFavourite:false,
        userId:"iamthebestdeveloper",
        userName:"alpertunga",
        password:"123alper132",
        categories:[],
        showPassword:false,
    }
];