import {useEffect, useState} from 'react';
import './App.css'
import NavBar from './components/NavBar.tsx';
import PasswordGenerator from './utils/PasswordGenerator.ts';
import {GeneratePasswordDto} from "./types/GeneratePasswordDto.ts";
import { ToastContainer, toast } from 'react-toastify';
import {Button, Card, Checkbox, Container, Form, Grid, Header, Icon, Input, Segment} from "semantic-ui-react";

function App() {
    const passwordGenerator = new PasswordGenerator();
    const generatePasswordDto = new GeneratePasswordDto();

    const [password, setPassword] = useState<string>("123456");

    const [savedPasswords, setSavedPasswords] = useState<string[]>([]);

    const [passwordLength, setPasswordLength] = useState<number>(12);

    const [includeNumbers, setIncludeNumbers] = useState<boolean>(true);
    const [includeLowercase, setIncludeLowercase] = useState<boolean>(true);
    const [includeUppercase, setIncludeUppercase] = useState<boolean>(false);
    const [includeSpecialChars, setIncludeSpecialChars] = useState<boolean>(false);

    useEffect(() => {

        handleGenerate();

    },[passwordLength,includeNumbers,includeLowercase,includeUppercase,includeSpecialChars]);

    const handleGenerate = () : void => {

        generatePasswordDto.Length = passwordLength;
        generatePasswordDto.IncludeNumbers = includeNumbers;
        generatePasswordDto.IncludeLowercaseCharacters = includeLowercase;
        generatePasswordDto.IncludeUppercaseCharacters = includeUppercase;
        generatePasswordDto.IncludeSpecialCharacters = includeSpecialChars;

        const newPass = passwordGenerator.Generate(generatePasswordDto);

        console.log(newPass);

        setPassword(newPass);

    }

    const handleSavePassword = () => {

        const samePassword = savedPasswords.find(x=>x===password);

        // 1 == "1"
        // 1 === "1"

        if(!samePassword)
            setSavedPasswords([...savedPasswords,password]);

    }

    const handleSavedPasswordDelete = (selectedPass:string) => {

        const newSavedPasswords = savedPasswords.filter((pass) => pass !== selectedPass);

        setSavedPasswords(newSavedPasswords);

    }

    const handleChange = (value:string) => {

        setPasswordLength(Number(value));

        //handleGenerate();
    }

    const handleCopyToClipBoard = () => {

        navigator.clipboard.writeText(password);
        toast("The selected password copied to the clipboard.");

    }

    return (
        <>
            <ToastContainer/>
            <NavBar/>
            <Container className="App">
                <Header as='h2' textAlign='center' color='green' style={{ fontSize: '36px', fontWeight: 'bold' }}>Secure Password Generator</Header>
                <Segment raised style={{backgroundColor: '#A2BEB9', boxShadow: '0 8px 16px 0 rgba(0,0,0,0.2)', transition: '0.3s', color: '#173A3A'}}>

                    <Grid>
                        <Grid.Row columns={2}>
                            <Grid.Column textAlign='center'>
                                <Header as='h4'>{password}</Header>
                                <Button icon onClick={handleSavePassword}><Icon name='save' /></Button>
                                <Button icon onClick={handleCopyToClipBoard}><Icon name='copy' /></Button>
                                <Button icon onClick={handleGenerate}><Icon name='refresh' /></Button>
                            </Grid.Column>
                            <Grid.Column>
                                <Form>
                                    <Form.Field>
                                        <label>Password Length</label>
                                        <Input
                                            id="passwordLengthSelector"
                                            type="number"
                                            value={passwordLength}
                                            min={6}
                                            max={35}
                                            onChange={(_, data) => handleChange(data.value)}
                                        />
                                    </Form.Field>
                                    <Form.Field>
                                        <Checkbox
                                            label="Include Numbers"
                                            checked={includeNumbers}
                                            onChange={(_, data) => setIncludeNumbers(data.checked || true)}
                                        />
                                    </Form.Field>
                                    <Form.Field>
                                        <Checkbox
                                            label="Include Lowercase Characters"
                                            checked={includeLowercase}
                                            onChange={(_, data) => setIncludeLowercase(data.checked || true)}
                                        />
                                    </Form.Field>
                                    <Form.Field>
                                        <Checkbox
                                            label="Include Uppercase Characters"
                                            checked={includeUppercase}
                                            onChange={(_, data) => setIncludeUppercase(data.checked || true)}
                                        />
                                    </Form.Field>
                                    <Form.Field>
                                        <Checkbox
                                            label="Include Special Characters"
                                            checked={includeSpecialChars}
                                            onChange={(_, data) => setIncludeSpecialChars(data.checked || true)}
                                        />
                                    </Form.Field>
                                </Form>
                            </Grid.Column>
                        </Grid.Row>
                    </Grid>

                    <Header as='h4' style={{paddingBottom:"15px"}}>Saved Passwords:</Header>
                    <Card.Group itemsPerRow={4} stackable>
                        {savedPasswords.map((pass,index) => (
                            <Card key={index}>
                                <Card.Content>
                                    <Card.Header>{pass}</Card.Header>
                                    <Card.Description>
                                        <Button icon onClick={() => handleSavedPasswordDelete(pass)}><Icon name='trash' /></Button>
                                    </Card.Description>
                                </Card.Content>
                            </Card>
                        ))}
                    </Card.Group>

                </Segment>
            </Container>
        </>
    )

}

export default App
