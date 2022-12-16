import { createSlice } from '@reduxjs/toolkit'

var initialState = []

const toastSlice = createSlice({
  name: 'toast',
  initialState,
  reducers: {
    showErrorNotification(state, action) {
      state.push({ message: action.payload, type: "danger" })
    },
    showSuccessNotification(state, action) {
      state.push({ message: action.payload, type: "success" })
    },
    removeNotification(state) {
      state.shift();
    },

  },
})

export const { showErrorNotification, showSuccessNotification, removeNotification } = toastSlice.actions
export default toastSlice.reducer