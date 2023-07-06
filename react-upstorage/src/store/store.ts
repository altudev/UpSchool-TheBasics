import { configureStore } from '@reduxjs/toolkit'
import countryReducer from "./features/country/countrySlice.ts";
import cityReducer from "./features/city/citySlice.ts";

export const store = configureStore({
    reducer: {
        //user:userSlice
        country:countryReducer,
        city:cityReducer
    },
})

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>
// Inferred type: {posts: PostsState, comments: CommentsState, users: UsersState}
export type AppDispatch = typeof store.dispatch