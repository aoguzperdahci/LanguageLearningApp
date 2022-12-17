import { createSlice } from '@reduxjs/toolkit'

var initialState = {
  id: 0,
  name: null,
  role: null,
}

const userSlice = createSlice({
  name: 'user',
  initialState,
  reducers: {
    setUser(state, action) {
      state.id = action.payload.id;
      state.name = action.payload.name;
      state.role = action.payload.role;
    },
  },
})

export const { setUser } = userSlice.actions
export default userSlice.reducer