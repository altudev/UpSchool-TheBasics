import type { RootState } from '../store/store.ts';
import { useSelector, useDispatch } from 'react-redux';
import { addCountry } from '../store/features/country/countrySlice';

function CountriesPage() {

    const countries = useSelector((state: RootState) => state.country.countries)
    const dispatch = useDispatch()


    return (
       <div>
           <ul>
               { countries.map((country) => (
                   <li key={country}>{country}</li>
               )) }
           </ul>
       </div>
    );
}

export default CountriesPage;