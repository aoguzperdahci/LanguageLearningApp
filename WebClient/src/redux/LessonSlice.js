import { createSlice, createAsyncThunk } from '@reduxjs/toolkit'

var initialAllLessons = [{}];
var activeLesson = {id:0, name:""};

var API = process.env.REACT_APP_API_KEY;

export const getAllLessons = createAsyncThunk('lessons/getAllLessons', async () => {
    const response = await fetch(API + "Lesson/getAllLessons", { method: "GET" });
    const data = await response.json();
    return data.data
})

export const getCurrentLesson = createAsyncThunk('lesson/getCurrentLesson', async (studentId) => {
    const response = await fetch(API + "Lesson/getCurrentLesson/studentId=" + studentId,{method: "GET"});
    const data = await response.json();
    return data.data
})


const lessonSlice = createSlice({
    name: 'lesson',
    initialAllLessons,
    reducers: {
        // omit reducer cases
    },
    extraReducers: builder => {
        builder
            
            .addCase(getAllLessons.fulfilled, (state, action) => {
                    state.initialAllLessons = action.payload;
            })
            .addCase(getCurrentLesson.fulfilled, (state, action) => {
                state.id = action.payload;
                state.name = action.payload;
            });
    }
})

export default lessonSlice.reducer;