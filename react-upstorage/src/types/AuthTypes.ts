
export type LocalUser = {
    id:string,
    email:string,
    firstName:string,
    lastName:string,
    accessToken:string,
    expires:string,
};

export type AuthLoginCommand = {
    email:string,
    password:string
}

export type LocalJwt = {
    accessToken:string,
    expires:string,
}