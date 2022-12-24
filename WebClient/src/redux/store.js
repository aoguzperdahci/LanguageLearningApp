import { configureStore } from '@reduxjs/toolkit'
import LessonSlice from './LessonSlice'
import ToastSlice from './ToastSlice'
import UserSlice from './UserSlice'

const store = configureStore({
    reducer: {
      toast: ToastSlice,
      user: UserSlice,
      lesson: LessonSlice,
    }
  })
  
  export default store
  