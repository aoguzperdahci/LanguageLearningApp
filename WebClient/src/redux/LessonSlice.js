import { createSlice, createAsyncThunk } from '@reduxjs/toolkit'

var initialState = {
    lessonList: [],
    activeLesson: {id:0, name:""},
    chosenLesson: {id: 0,
        lessonContent: "",
        level:"",
        multimediaContent:null,
        name:"",
        order:0}
};

var API = process.env.REACT_APP_API_KEY;
export const getSingleLesson = createAsyncThunk('lessons/getSingleLesson',async (lessonId) => {
    const response = await fetch(API+"Lesson/getSingleLesson?lessonId="+lessonId, {method: "GET"});
    const data = await response.json();
    return data.data;

})
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
            })
            .addCase(getSingleLesson.fulfilled, (state, action) => {
                state.chosenLesson = action.payload;
        });
    }
})

export default lessonSlice.reducer;