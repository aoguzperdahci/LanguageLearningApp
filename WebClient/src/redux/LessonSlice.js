import { createSlice, createAsyncThunk } from '@reduxjs/toolkit'

var initialState = {
    lessonList: [],
    activeLesson: {id:0, name:""},
};

var API = process.env.REACT_APP_API_KEY;

export const getAllLessons = createAsyncThunk('lessons/getAllLessons', async () => {
    const response = await fetch(API + "Lesson/getAllLessons", { method: "GET" });
    const data = await response.json();
    return data.data
})

export const getCurrentLesson = createAsyncThunk('lesson/getCurrentLesson', async (studentId) => {
    const response = await fetch(API + "Lesson/getCurrentLesson?studentId=" + studentId,{method: "GET"});
    const data = await response.json();
    return data.data
})


const lessonSlice = createSlice({
    name: 'lesson',
    initialState,
    reducers: {
        // omit reducer cases
    },
    extraReducers: builder => {
        builder
            .addCase(getAllLessons.fulfilled, (state, action) => {
                    state.lessonList = action.payload;
            })
            .addCase(getCurrentLesson.fulfilled, (state, action) => {
                state.activeLesson.id = action.payload.id;
                state.activeLesson.name = action.payload.name;
            });
    }
})

export default lessonSlice.reducer;