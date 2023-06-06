import './App.css'
import NavBar from './components/NavBar.tsx';
import { ToastContainer } from 'react-toastify';
import {Container} from "semantic-ui-react";
import {Route, Routes} from "react-router-dom";
import PasswordGeneratorPage from "./pages/PasswordGeneratorPage.tsx";
import AccountsPage from "./pages/AccountsPage.tsx";
import NotFoundPage from "./pages/NotFoundPage.tsx";
import {useState} from "react";
import {AccountGetAllDto} from "./types/AccountTypes.ts";
import {LocalUser} from "./types/AuthTypes.ts";

const dummyAccounts:AccountGetAllDto[] = [
    {
        Id:"12345",
        Title:"Yemek Sepeti",
        Url:"www.yemeksepeti.com",
        IsFavourite:false,
        UserId:"iamthebestdeveloper",
        UserName:"alpertunga",
        Password:"123alper132",
        Categories:[],
        ShowPassword:false,
    },
    {
        Id:"123456",
        Title:"Getir",
        Url:"www.getir.com",
        IsFavourite:false,
        UserId:"iamthebestdeveloper",
        UserName:"alpertunga",
        Password:"123alper132",
        Categories:[],
        ShowPassword:false,
    }
];

function App() {

    const [accounts,setAccounts] = useState<AccountGetAllDto[]>(dummyAccounts);

    const [appUser, setAppUser] = useState<LocalUser | undefined>(undefined);

    return (
        <>
            <ToastContainer/>
            <NavBar accounts={accounts}/>
            <Container className="App">
            <Routes>
                <Route path="/" element={<PasswordGeneratorPage />} />
                <Route path="/accounts" element={<AccountsPage accounts={accounts} setAccounts={setAccounts} />} />
                <Route path="*" element={<NotFoundPage />} />
            </Routes>
            </Container>
        </>
    )

}

export default App
