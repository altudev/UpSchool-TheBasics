import {useEffect, useState} from "react";
import { Button, Form, Input, Checkbox, Header, Segment } from "semantic-ui-react";
import api from "../utils/axiosInstance.ts";
import { AccountAddCommand } from "../types/AccountTypes.ts";
import {ApiResponse} from "../types/GenericTypes.ts";
import {HubConnection, HubConnectionBuilder} from "@microsoft/signalr";
import {LocalJwt} from "../types/AuthTypes.ts";

const BASE_SIGNALR_URL = import.meta.env.VITE_API_SIGNALR_URL;

function AddAccountPage() {

    const [accountHubConnection,setAccountHubConnection] = useState<HubConnection | undefined>(undefined);


    useEffect(() => {

        const startConnection = async () => {

            const jwtJson = localStorage.getItem("upstorage_user");
            if(jwtJson){
                const localJwt:LocalJwt =JSON.parse(jwtJson);

                const connection = new HubConnectionBuilder()
                    .withUrl(`${BASE_SIGNALR_URL}Hubs/AccountHub?access_token=${localJwt.accessToken}`)
                    .withAutomaticReconnect()
                    .build();

                await connection.start();

                setAccountHubConnection(connection);
            }



        }

        if(!accountHubConnection){
            startConnection();
        }


    },[])

    const [account, setAccount] = useState<AccountAddCommand>({
        title: '',
        userName: '',
        password: '',
        url: '',
        isFavourite: false,
        categoryIds: []
    });

    const handleSubmit = async () => {

        const accountId = await accountHubConnection?.invoke<string>("AddANewAccount",account);

        console.log(accountId)


        /*   const response = await api.post<ApiResponse<string>>("/Accounts", account);
           if(response.data) {
               console.log(`Account with ID: ${response.data.data} added successfully.`);
               // You can redirect to accounts page or show success message here.
           }*/
    }

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setAccount({
            ...account,
            [e.target.name]: e.target.value
        });
    }

    return (
        <Segment padded='very'>
            <Header as='h1' textAlign='center' className="main-header">Add Account</Header>
            <Form onSubmit={handleSubmit}>
                <Form.Field>
                    <label>Title</label>
                    <Input placeholder='Title' name="title" onChange={handleChange} />
                </Form.Field>
                <Form.Field>
                    <label>Username</label>
                    <Input placeholder='Username' name="userName" onChange={handleChange} />
                </Form.Field>
                <Form.Field>
                    <label>Password</label>
                    <Input placeholder='Password' name="password" onChange={handleChange} />
                </Form.Field>
                <Form.Field>
                    <label>URL</label>
                    <Input placeholder='URL' name="url" onChange={handleChange} />
                </Form.Field>
                <Form.Field>
                    <Checkbox label='Favourite' name="isFavourite" onChange={() => setAccount({...account, isFavourite: !account.isFavourite})} />
                </Form.Field>
                <Button type='submit'>Submit</Button>
            </Form>
        </Segment>
    );
}

export default AddAccountPage;
