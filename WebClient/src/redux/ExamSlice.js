import { createSlice, createAsyncThunk } from '@reduxjs/toolkit'

var initialState = {
    questionNumber: 0,
    question: {},
    status: "empty",
    result: [],
};

var API = process.env.REACT_APP_API_KEY;

export const createExam = createAsyncThunk('exam/createExam', async (studentId) => {
    const response = await fetch(API + "Exam/createExam?studentId=" + studentId, { method: "POST" });
    const data = await response.json();
    return data.success
})

export const getNextQuestion = createAsyncThunk('exam/getNextQuestion', async (studentId) => {
    const response = await fetch(API + "ExamQuestion/getNextQuestion?studentId=" + studentId);
    const data = await response.json();
    return data.data
})

export const saveAnswer = createAsyncThunk('exam/saveAnswer', async ({ studentId, answer }) => {
    console.log("answer", answer)
    const response = await fetch(API + "ExamQuestion/saveStudentAnswer?studentId=" + studentId + "&answer=" + answer, { method: "POST" });
    const data = await response.json();
    return data.success
})

export const getExamResult = createAsyncThunk('exam/getExamResult', async (studentId) => {
    const response = await fetch(API + "ExamQuestion/getExamResult?studentId=" + studentId);
    const data = await response.json();
    return data
})


const examSlice = createSlice({
    name: 'exam',
    initialState,
    reducers: {
        // omit reducer cases
    },
    extraReducers: builder => {
        builder
            .addCase(createExam.pending, (state, action) => {
                state.status = "loading";
            })
            .addCase(createExam.fulfilled, (state, action) => {
                if (action.payload) {
                    state.status = "created";
                    state.result = [];
                }
            })
            .addCase(getNextQuestion.pending, (state, action) => {
                state.status = "loading";
            })
            .addCase(getNextQuestion.fulfilled, (state, action) => {
                state.question = action.payload;
                state.questionNumber++;
                state.status = "served";
            })
            .addCase(saveAnswer.pending, (state, action) => {
                state.status = "loading";
            })
            .addCase(saveAnswer.fulfilled, (state, action) => {
                if (action.payload) {
                    state.status = "saved";
                }
            })
            .addCase(getExamResult.pending, (state, action) => {
                state.status = "loading";
            })
            .addCase(getExamResult.fulfilled, (state, action) => {
                state.result = action.payload
                state.question = {};
                state.status = "empty";
                state.questionNumber = 0;
            })
    }
})

export default examSlice.reducer;
