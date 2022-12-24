import { createSlice, createAsyncThunk } from '@reduxjs/toolkit'

var initialState = {
    questionNumber: 0,
    question: {},
    status: "empty"
};

// var initialState = {
//     "questionNumber": 1,
//     "question": {
//         "id": 5,
//         "questionText": "Lilly has been lying on the floor ...... three hours now.",
//         "difficulty": 0,
//         "correctAnswer": "",
//         "lesson": null
//     },
//     "status": "served"
// }
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


    }
})

export default examSlice.reducer;
