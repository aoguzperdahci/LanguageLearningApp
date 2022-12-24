import { configureStore } from '@reduxjs/toolkit'
import ExamSlice from './ExamSlice'
import ToastSlice from './ToastSlice'
import UserSlice from './UserSlice'

const store = configureStore({
    reducer: {
      toast: ToastSlice,
      user: UserSlice,
      exam: ExamSlice,
    }
  })
  
  export default store
  