import { createSlice } from '@reduxjs/toolkit'
import type { PayloadAction } from '@reduxjs/toolkit'

export type CountryState = {
    countries: string[],
    isLoading:boolean,
}

const initialState : CountryState = {
    countries:["Sweden","Norway"],
    isLoading:false,
}

export const countrySlice = createSlice({
    name: 'country',
    initialState,
    reducers: {
        addCountry: (state, action: PayloadAction<string>) => {
            state.countries.push(action.payload);
        },
        removeCountry:(state, action: PayloadAction<string>) => {
           state.countries = state.countries.filter(country => country!==action.payload);
        },
    },
})

// Action creators are generated for each case reducer function
export const { addCountry, removeCountry } = countrySlice.actions

export default countrySlice.reducer