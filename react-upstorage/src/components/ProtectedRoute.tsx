import React, {useContext} from "react";
import {AppUserContext} from "../context/StateContext.tsx";
import {Navigate} from "react-router-dom";

type ProtectedRouteProps = {
    children:React.ReactElement
}
export default function ProtectedRoute( { children } : ProtectedRouteProps ) {

    const { appUser } = useContext(AppUserContext);

    if(!appUser)
        return <Navigate to="/login" />

    return children;
}