import { configureStore } from '@reduxjs/toolkit'
import ExamSlice from './ExamSlice'
import LessonSlice from './LessonSlice'
import ToastSlice from './ToastSlice'
import UserSlice from './UserSlice'

const store = configureStore({
    reducer: {
      toast: ToastSlice,
      user: UserSlice,
      exam: ExamSlice,
      lesson: LessonSlice,
    }
  })
  
  export default store
  