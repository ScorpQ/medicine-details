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
}

export default Medicine
