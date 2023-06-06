import {Button, Card, Grid, Icon, Input} from "semantic-ui-react";
import {AccountGetAllDto} from "../types/AccountTypes.ts";

export type AccountCardProps = {
    account:AccountGetAllDto,
    index:number,
    onPasswordVisibilityToggle:(id:string) => void,
    onEditButtonClick:(id:string) => void,
    onDeleteButtonClick:(id:string) => void
};

function AccountCard({ index,account,onPasswordVisibilityToggle,onEditButtonClick,onDeleteButtonClick } : AccountCardProps) {

    return (
        <Grid.Column key={index}>
            <Card color={index % 2 === 0 ? 'blue' : 'red'} raised>
                <Card.Content header={account.title} textAlign='center' />
                <Card.Content>
                    <Input type="text" value={account.userName} textAlign='center' />
                    <Input
                        icon={{
                            name: account.showPassword ? 'eye slash outline' : 'eye',
                            link: true,
                            onClick: () => onPasswordVisibilityToggle(account.id)
                        }}
                        type={account.showPassword ? "text" : "password"}
                        value={account.password}
                        textAlign='center'
                    />
                </Card.Content>
                <Card.Content extra>
                    <div className='ui two buttons'>
                        <Button basic color='blue' onClick={() => onEditButtonClick(account.id)}><Icon name='edit' /> Edit</Button>
                        <Button basic color='red' onClick={() => onDeleteButtonClick(account.id)}><Icon name='delete' /> Delete</Button>
                    </div>
                </Card.Content>
            </Card>
        </Grid.Column>
    );
}

export default AccountCard;