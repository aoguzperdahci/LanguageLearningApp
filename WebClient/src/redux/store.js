import { configureStore } from '@reduxjs/toolkit'
import ToastSlice from './ToastSlice'

const store = configureStore({
    reducer: {
      toast: ToastSlice,
    }
  })
  
  export default store
  