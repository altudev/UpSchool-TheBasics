import type { RootState } from '../store/store.ts';
import { useSelector, useDispatch } from 'react-redux';
import {fetchAllCountries, removeCountry} from '../store/features/country/countrySlice';
import {useEffect, useState} from "react";
import {Button, Form, Header, Input, Segment} from "semantic-ui-react";
import {addCity, removeCity} from "../store/features/city/citySlice.ts";
import {CountriesGetAllQuery} from "../types/CountryTypes.ts";

function CountriesPage() {

    const paginatedCountries = useSelector((state: RootState) => state.country.paginatedCountries);
    const isLoading = useSelector((state: RootState) => state.country.isLoading);
    const cities = useSelector((state:RootState) => state.city.cities);

    const dispatch = useDispatch()

    useEffect(() => {

        const fetchCountries = async () => {

            const countriesGetAllQuery:CountriesGetAllQuery = {
                pageNumber:1,
                pageSize:10,
            };

            // @ts-ignore
            await dispatch(fetchAllCountries(countriesGetAllQuery));
        }

        fetchCountries();

    },[]);

    /*const [newCountry, setNewCountry] = useState<string>("");*/

    const [newCity, setNewCity] = useState<string>("");

 /*   const handleCountrySubmit = () => {
       /!* dispatch(addCountry(newCountry));*!/
    };*/

    const handleCitySubmit = () => {
       dispatch(addCity(newCity))
    };

/*    const handleCountryChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setNewCountry(e.target.value);
    };*/

    const handleCityChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setNewCity(e.target.value);
    };

    return (
        <>
       <div>
           { isLoading }

           <ul>
               { paginatedCountries && paginatedCountries.items.map((country) => (
                   <li key={country.id} onClick={async () => await dispatch(removeCountry(country.id))}>{country.name}</li>
               )) }
           </ul>
       </div>

            <div>
                <ul>
                    { cities.map((city) => (
                        <li key={city} onClick={() => dispatch(removeCity(city))}>{city}</li>
                    )) }
                </ul>
            </div>

           {/* <Segment padded='very'>
                <Header as='h1' textAlign='center' className="main-header">Add a New Country</Header>
                <Form onSubmit={handleCountrySubmit}>
                    <Form.Field>
                        <label>Country Name</label>
                        <Input placeholder='Country' name="country" onChange={handleCountryChange} />
                    </Form.Field>
                    <Button type='submit'>Submit</Button>
                </Form>
            </Segment>*/}

            <Segment padded='very'>
                <Header as='h1' textAlign='center' className="main-header">Add a New City</Header>
                <Form onSubmit={handleCitySubmit}>
                    <Form.Field>
                        <label>City Name</label>
                        <Input placeholder='City' name="city" onChange={handleCityChange} />
                    </Form.Field>
                    <Button type='submit'>Submit</Button>
                </Form>
            </Segment>

            </>
    );
}

export default CountriesPage;