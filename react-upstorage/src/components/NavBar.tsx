import {Container, Menu, Image, Icon} from "semantic-ui-react";
import {NavLink} from "react-router-dom";
import {AccountGetAllDto} from "../types/AccountTypes.ts";
import {LocalUser} from "../types/AuthTypes.ts";

export type NavbarProps = {
    accounts:AccountGetAllDto[],
    appUser:LocalUser | undefined
}

const NavBar = ( { accounts, appUser } : NavbarProps ) => {
    //

    return (
        <Menu fixed='top' inverted>
            <Container>
                <Menu.Item as='a' header>
                    <Image size='mini' src='/vite.svg' style={{ marginRight: '1.5em' }} />
                    UpStorage
                </Menu.Item>
                <Menu.Item as={NavLink} to="/">Home</Menu.Item>
                <Menu.Item as={NavLink} to="/accounts">Accounts ({accounts.length})</Menu.Item>
                <Menu.Item as={NavLink} to="/dafasdqweasdaf">Not Found</Menu.Item>
                {!appUser && <Menu.Item as={NavLink} to="/login" position="right"><Icon name="sign-in" /> Login</Menu.Item>}
            </Container>
        </Menu>
    );
}

export default  NavBar;