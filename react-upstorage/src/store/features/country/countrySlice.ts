import {AsyncThunkAction, createAsyncThunk, createSlice, PayloadAction} from '@reduxjs/toolkit'
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
        setLoading: (state, action: PayloadAction<boolean>) => {
            state.isLoading = action.payload;
        },
        /*addCountry: (state, action: PayloadAction<string>) => {
            state.countries.push(action.payload);
        },
        removeCountry:(state, action: PayloadAction<string>) => {
           state.countries = state.countries.filter(country => country!==action.payload);
        },*/
    },
    extraReducers: (builder) => {
        builder
            .addCase(fetchAllCountries.pending, (state) => {
                state.isLoading = true;
            })
            .addCase(fetchAllCountries.fulfilled, (state, { payload }) => {
                state.paginatedCountries = payload;
                state.isLoading = false;
            })
            .addCase(fetchAllCountries.rejected, (state) => {
                state.isLoading = false;
            })
            .addCase(removeCountry.pending, (state) => {
                state.isLoading = true;
            })
            .addCase(removeCountry.fulfilled, (state, { payload }) => {
                state.paginatedCountries.items = state.paginatedCountries.items.filter(
                    (country) => country.id !== payload
                );
                state.paginatedCountries.totalCount -= 1;
                state.isLoading = false;
            })
            .addCase(removeCountry.rejected, (state) => {
                state.isLoading = false;
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

export const removeCountry = createAsyncThunk<string,string>(
    'countries/remove',
    // Declare the type your function argument here:
    async (id) => {

        // an API call

       return id;
    }
)

// Action creators are generated for each case reducer function
/*export const { addCountry, removeCountry } = countrySlice.actions*/
/*export const {  } = countrySlice.actions*/

export default countrySlice.reducer