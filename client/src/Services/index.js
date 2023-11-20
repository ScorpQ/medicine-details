import axios from 'axios'

const Medicine = {
  getUser: async () => {
    try {
      const response = await axios.get('https://localhost:7239/api/User/GetAllUser')
      console.log(response.data)
    } catch (error) {
      console.error('API SOURCE HATALI')
    }
  },

  login: async (name, password) => {
    try {
      const response = await axios.post('https://localhost:7239/api/Auth/Login',{
        tc: name,
        password: password
      })
      console.log(response)
    } catch (error) {
      alert('API SOURCE HATALI')
    }
  }
}

export default Medicine
