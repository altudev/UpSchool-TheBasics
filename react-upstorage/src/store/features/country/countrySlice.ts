import {createAsyncThunk, createSlice} from '@reduxjs/toolkit'
import {PaginatedList} from "../../../types/GenericTypes.ts";
import {CountriesGetAllQuery, CountryGetAllDto} from "../../../types/CountryTypes.ts";
import api from "../../../utils/axiosInstance.ts";

export type CountryState = {
    paginatedCountries:PaginatedList<CountryGetAllDto>,
    isLoading:boolean,
}

const initialState : CountryState = {
    paginatedCountries: {items:[],hasNextPage:false,hasPreviousPage:false,pageNumber:1,totalPages:1,totalCount:0},
    isLoading:false,
}

export const countrySlice = createSlice({
    name: 'country',
    initialState,
    reducers: {
        /*addCountry: (state, action: PayloadAction<string>) => {
            state.countries.push(action.payload);
        },
        removeCountry:(state, action: PayloadAction<string>) => {
           state.countries = state.countries.filter(country => country!==action.payload);
        },*/
    },
    extraReducers:(builder) => {
        builder.addCase(fetchAllCountries.fulfilled, (state, { payload }) => {
            state.paginatedCountries = payload
        });
    },
});

export const fetchAllCountries = createAsyncThunk<PaginatedList<CountryGetAllDto>,CountriesGetAllQuery>(
    'countries/fetchAll',
    // Declare the type your function argument here:
    async (countriesGetAllQuery) => {

        const response = await api.post<PaginatedList<CountryGetAllDto>>("/Countries/GetAll",countriesGetAllQuery);

       return response.data;
    }
)

// Action creators are generated for each case reducer function
/*export const { addCountry, removeCountry } = countrySlice.actions*/
/*export const {  } = countrySlice.actions*/

export default countrySlice.reducer