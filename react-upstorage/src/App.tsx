import './App.css'
import NavBar from './components/NavBar.tsx';
import { ToastContainer } from 'react-toastify';
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
import { useNavigate } from "react-router-dom";

function App() {

    const navigate = useNavigate();

    const [accounts,setAccounts] = useState<AccountGetAllDto[]>([]);

    const [appUser, setAppUser] = useState<LocalUser | undefined>(undefined);

    useEffect(() => {

       const jwtJson = localStorage.getItem("upstorage_user");

       if(!jwtJson){
           navigate("/login");
           return;
       }

       const localJwt:LocalJwt = JSON.parse(jwtJson);

        const { uid, email, given_name, family_name} = getClaimsFromJwt(localJwt.accessToken);

        const expires:string = localJwt.expires;

        setAppUser({ id:uid,email,firstName:given_name,lastName:family_name,expires,accessToken:localJwt.accessToken});


    },[]);

    return (
        <>
            <ToastContainer/>
            <NavBar accounts={accounts} appUser={appUser}/>
            <Container className="App">
            <Routes>
                <Route path="/" element={<PasswordGeneratorPage />} />
                <Route path="/accounts" element={<AccountsPage accounts={accounts} setAccounts={setAccounts} />} />
                <Route path="/login" element={<LoginPage setAppUser={setAppUser} />} />
                <Route path="*" element={<NotFoundPage />} />
            </Routes>
            </Container>
        </>
    )

}

export default App
