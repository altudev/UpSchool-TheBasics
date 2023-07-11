import axios from 'axios';
import { LocalJwt } from "../types/AuthTypes.ts";

const BASE_URL = import.meta.env.VITE_API_URL;

const api = axios.create({
    baseURL: BASE_URL
});

// Function to refresh the access token using the refresh token
const refreshAccessToken = async () => {
    try {
        const refreshToken = "";

        // Make a request to your API endpoint to refresh the access token
        const response = await axios.post(`${BASE_URL}/Authentication/RefreshToken`, { refreshToken });

        // Update the access token in local storage
        const localJwt: LocalJwt = response.data; // Assuming the response returns a new JWT
        localStorage.setItem("upstorage_user", JSON.stringify(localJwt));

        return localJwt.accessToken;
    } catch (error) {
        // Handle the error, e.g., redirect to the login page
        throw error;
    }
};


api.interceptors.request.use((config)=>{

    const jwtJson = localStorage.getItem("upstorage_user");

    if(jwtJson){

        const localJwt:LocalJwt =JSON.parse(jwtJson);

        config.headers["Authorization"] = `Bearer ${localJwt.accessToken}`;
    }

    return config;
});

// Interceptor for handling token refresh
api.interceptors.response.use(
    (response) => response,
    async (error) => {
        const originalRequest = error.config;

        // Check if the error response status is 401 Unauthorized and if it's not a retry attempt
        if (error.response.status === 401 && !originalRequest._retry) {
            originalRequest._retry = true;

            try {
                const accessToken = await refreshAccessToken();

                // Update the Authorization header with the new access token
                originalRequest.headers['Authorization'] = `Bearer ${accessToken}`;

                // Retry the original request with the updated headers
                return axios(originalRequest);
            } catch (refreshError) {
                // Handle the error, e.g., redirect to the login page
                throw refreshError;
            }
        }

        // For other errors, reject the request
        return Promise.reject(error);
    }
);

export default api;



