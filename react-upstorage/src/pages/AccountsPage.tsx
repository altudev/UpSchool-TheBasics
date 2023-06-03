import {AccountGetAllDto} from "../types/AccountTypes.ts";
import {useEffect, useState} from "react";
import {Button, Card, Divider, Grid, Header, Icon, Input, Segment, Select} from "semantic-ui-react";
import "./AccountsPage.css";

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

const options = [
    { key: '1', text: 'Ascending', value: 'true' },
    { key: '2', text: 'Descending', value: 'false' }
];

function AccountsPage() {

    const [accounts,setAccounts] = useState<AccountGetAllDto[]>(dummyAccounts);

    useEffect(() => {

        return;

    },[]);

    // @ts-ignore
    const onPasswordVisibilityToggle = (id:string) => {
        // Create a new array with the same accounts, but with the showPassword property of the account with the given id toggled
        const updatedAccounts = accounts.map(account => {
            if (account.Id === id) {
                // Toggle the showPassword property

                return {...account, ShowPassword: !account.ShowPassword};
            } else {
                // Leave the account unchanged
                return account;
            }
        });

        // Update the state with the new array
        setAccounts(updatedAccounts);
    }


    const onAddButtonClick = () => {
        console.log('Add button clicked');
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
                    <Grid.Column key={index}>
                        <Card color={index % 2 === 0 ? 'blue' : 'red'} raised>
                            <Card.Content header={account.Title} textAlign='center' />
                            <Card.Content>
                                <Input type="text" value={account.UserName} textAlign='center' />
                                <Input
                                    icon={{
                                        name: account.ShowPassword ? 'eye slash outline' : 'eye',
                                        link: true,
                                        onClick: () => onPasswordVisibilityToggle(account.Id)
                                    }}
                                    type={account.ShowPassword ? "text" : "password"}
                                    value={account.Password}
                                    textAlign='center'
                                />
                            </Card.Content>
                            <Card.Content extra>
                                <div className='ui two buttons'>
                                    <Button basic color='blue' onClick={() => onEditButtonClick(account.Id)}><Icon name='edit' /> Edit</Button>
                                    <Button basic color='red' onClick={() => onDeleteButtonClick(account.Id)}><Icon name='delete' /> Delete</Button>
                                </div>
                            </Card.Content>
                        </Card>
                    </Grid.Column>
                ))}
            </Grid>
        </Segment>
    );
}

export default AccountsPage;