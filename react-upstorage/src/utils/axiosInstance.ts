import axios from 'axios';
import {LocalJwt} from "../types/AuthTypes.ts";

const BASE_URL = import.meta.env.VITE_API_URL;


const api = axios.create({
    baseURL:BASE_URL
});

api.interceptors.request.use((config) => {

    const jwtJson = localStorage.getItem("upstorage_user");

    if (jwtJson) {

        const localJwt:LocalJwt = JSON.parse(jwtJson);

        config.headers["Authorization"] = `Bearer ${localJwt.accessToken}`;
    }

    return config;
});

export default  api;