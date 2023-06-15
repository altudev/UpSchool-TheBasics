import {useContext, useEffect} from "react";
import {Button, Divider, Grid, Header, Icon, Input, Segment, Select} from "semantic-ui-react";
import "./AccountsPage.css";
import AccountCard from "../components/AccountCard.tsx";
import {AccountsContext} from "../context/StateContext.tsx";
import api from "../utils/axiosInstance.ts";
import { PaginatedList} from "../types/GenericTypes.ts";
import {AccountGetAllDto} from "../types/AccountTypes.ts";
import {useNavigate} from "react-router-dom";


const options = [
    { key: '1', text: 'Ascending', value: 'true' },
    { key: '2', text: 'Descending', value: 'false' }
];

/*export type AccountsPageProps = {

}*/

function AccountsPage( ) {

    const navigate = useNavigate();

    const { accounts, setAccounts } = useContext(AccountsContext);

    useEffect(() => {
        const fetchAccounts = async () => {

            const response = await api.get<PaginatedList<AccountGetAllDto>>("/Accounts");

            setAccounts(response.data.items);
        }

        fetchAccounts();

        return;

    },[]);



    const onPasswordVisibilityToggle = (id:string) => {
        // Create a new array with the same accounts, but with the showPassword property of the account with the given id toggled
        const updatedAccounts = accounts.map(account => {
            if (account.id === id) {
                // Toggle the showPassword property

                return {...account, ShowPassword: !account.showPassword};
            } else {
                // Leave the account unchanged
                return account;
            }
        });

        // Update the state with the new array
        setAccounts(updatedAccounts);
    }


    const onAddButtonClick = () => {
        navigate("/accounts/add");
    }

    const onSearchInputChange = () => {
        console.log('Search input changed');
    }

    const onSelectChange = () => {
        console.log('Select option changed');
    }

    const onEditButtonClick = (id: string) => {
        console.log(`Edit button clicked for id: ${id}`);
    }

    const onDeleteButtonClick = (id: string) => {
        console.log(`Delete button clicked for id: ${id}`);
    }

    return (
        <Segment padded='very'>
            <Header as='h1' textAlign='center' className="main-header">My Accounts</Header>
            <div className="ui fitted segment d-flex justify-center">
                <Button color='green' onClick={onAddButtonClick}><Icon name='add circle' /> Add</Button>
                <Input className="ml-2" icon='search' placeholder="Search" onChange={onSearchInputChange} />
                <Select className="ml-2" placeholder='Select order' options={options} onChange={onSelectChange} />
            </div>
            <Divider section />
            <Grid columns={3} stackable>
                {accounts.map((account, index) =>(
                    <AccountCard key={index} account={account} index={index} onPasswordVisibilityToggle={onPasswordVisibilityToggle}
                                 onEditButtonClick={onEditButtonClick} onDeleteButtonClick={onDeleteButtonClick} />
                ))}
            </Grid>
        </Segment>
    );
}

export default AccountsPage;