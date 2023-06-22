import './App.css'
import NavBar from './components/NavBar.tsx';
import {ToastContainer} from 'react-toastify';
import {Container} from "semantic-ui-react";
import {Route, Routes} from "react-router-dom";
import PasswordGeneratorPage from "./pages/PasswordGeneratorPage.tsx";
import AccountsPage from "./pages/AccountsPage.tsx";
import NotFoundPage from "./pages/NotFoundPage.tsx";
import {useEffect, useState} from "react";
import {AccountGetAllDto} from "./types/AccountTypes.ts";
import {LocalJwt, LocalUser} from "./types/AuthTypes.ts";
import LoginPage from "./pages/LoginPage.tsx";
import {getClaimsFromJwt} from "./utils/jwtHelper.ts";
import {useNavigate} from "react-router-dom";
import {AppUserContext, AccountsContext} from "./context/StateContext.tsx";
import {dummyAccounts} from "./utils/dummyData.ts";
import ProtectedRoute from "./components/ProtectedRoute.tsx";
import AccountsAddPage from "./pages/AccountsAddPage.tsx";
import SocialLogin from "./pages/SocialLogin.tsx";

function App() {

    const navigate = useNavigate();

    const [accounts, setAccounts] = useState<AccountGetAllDto[]>(dummyAccounts);

    const [appUser, setAppUser] = useState<LocalUser | undefined>(undefined);

    useEffect(() => {

        const jwtJson = localStorage.getItem("upstorage_user");

        if (!jwtJson) {
            navigate("/login");
            return;
        }

        const localJwt: LocalJwt = JSON.parse(jwtJson);

        const {uid, email, given_name, family_name} = getClaimsFromJwt(localJwt.accessToken);

        const expires: string = localJwt.expires;

        setAppUser({
            id: uid,
            email,
            firstName: given_name,
            lastName: family_name,
            expires,
            accessToken: localJwt.accessToken
        });


    }, []);

    return (
        <>
            <AppUserContext.Provider value={{appUser, setAppUser}}>
                <AccountsContext.Provider value={{accounts, setAccounts}}>
                    <ToastContainer/>
                    <NavBar />
                    <Container className="App">
                        <Routes>
                            <Route path="/" element={
                                <ProtectedRoute>
                                    <PasswordGeneratorPage/>
                                </ProtectedRoute>
                            }/>
                            <Route path="/accounts" element={
                                <ProtectedRoute>
                                    <AccountsPage />
                                </ProtectedRoute>
                            }/>
                            <Route path="/accounts/add" element={
                                <ProtectedRoute>
                                    <AccountsAddPage />
                                </ProtectedRoute>
                            }/>
                            <Route path="/login" element={<LoginPage/>}/>
                            <Route path="/social-login" element={<SocialLogin/>}/>
                            <Route path="*" element={<NotFoundPage/>}/>
                        </Routes>
                    </Container>
                </AccountsContext.Provider>
            </AppUserContext.Provider>
        </>
    )

}


export default App