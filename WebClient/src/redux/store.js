import { configureStore } from '@reduxjs/toolkit'
import ToastSlice from './ToastSlice'
import UserSlice from './UserSlice'

const store = configureStore({
    reducer: {
      toast: ToastSlice,
      user: UserSlice,
    }
  })
  
  export default store
  