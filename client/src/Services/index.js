import axios from 'axios'

const Medicine = {
  getUser: async () => {
    try {
      const response = await axios.get('https://localhost:7239/api/User/GetAllUser')
    } catch (error) {
      console.error('API SOURCE HATALI')
    }
  },

  Physicianlogin: async (name, password) => {
    try {
      const response = await axios.post('https://localhost:7239/api/DoctorAuth/Login', {
        tc: name,
        password: password,
      })
      // response.status
      return response
    } catch (error) {
      alert('API SOURCE HATALI')
    }
  },

  Patientlogin: async (name, password) => {
    try {
      const response = await axios.post('https://localhost:7239/api/PatientAuth/Login', {
        tc: name,
        password: password,
      })
      return response
    } catch (error) {
      alert('API SOURCE HATALI')
    }
  },

  getPatientReports: async (id) => {
    try {
      const response = await axios.get(`https://localhost:7239/api/Prescriptions/GetPatientDto?TC=${id}`)
      return response
    } catch (error) {
      alert(error)
    }
  },

  getPhysicianReports: async (id) => {
    try {
      const response = await axios.get(`https://localhost:7239/api/Prescriptions/GetDoctorDto?TC=${id}`)
      return response
    } catch (error) {
      alert(error)
    }
  },

  getMedicineDetails: async (id, pid) => {
    try {
      const response = await axios.get(`https://localhost:7239/api/MedicineDetails/GetId?id=${id}&pid=${pid}`)
      return response
    } catch (error) {
      alert(error)
    }
  },

  medicines: async (doctorTC) => {
    try {
      const response = await axios.get(`https://localhost:7239/api/Medicines/GetDto?TC=${doctorTC}`)
      return response
    } catch (error) {
      alert(error)
    }
  },

  period: async () => {
    try {
      const response = await axios.get(`https://localhost:7239/api/TimeOfUses/GetAll`)
      return response
    } catch (error) {
      alert(error)
    }
  },

  addPrescription: async (doctorTC, patientTC, medicineId, startDate, endDate, timeOfUse, pieces, info) => {
    return await axios.post(`https://localhost:7239/api/Prescriptions/Add`, {
      doctorTC: doctorTC,
      patientTC: patientTC,
      medicineId: medicineId,
      startDate: startDate,
      endDate: endDate,
      timeOfUse: timeOfUse,
      pieces: pieces,
      info: info,
    })
  },

  deletePrescription: async (id) => {
    return await axios.delete(`https://localhost:7239/api/Prescriptions/Delete?id=${id}`)
  },

  sendQuestion: async (patientTC, doctorTC, prescripId, descrip) => {
    return await axios.post(`https://localhost:7239/api/QuestionAnswers/Add`, {
      doctorTC: doctorTC,
      patientTC: patientTC,
      title: 'hastaSoru',
      question: descrip,
      answer: '',
      prescriptionId: prescripId,
      answered: false,
    })
  },

  IsThereQuestion: async (id) => {
    try {
      const response = await axios.get(`https://localhost:7239/api/QuestionAnswers/GetByPrescriptionIdBool?id=${id}`)
      return response
    } catch (error) {
      alert(error)
    }
  },

  getQuestions: async (id) => {
    try {
      const response = await axios.get(`https://localhost:7239/api/QuestionAnswers/GetByPrescriptionId?id=${id}`)
      return response
    } catch (error) {
      alert(error)
    }
  },

  getQuestionsByPhysicianNotAnswered: async (id) => {
    try {
      const response = await axios.get(
        `https://localhost:7239/api/QuestionAnswers/GetAllNotAnsweredByDoctorTC?doctorTC=${id}`
      )
      return response
    } catch (error) {
      alert(error)
    }
  },

  getQuestionsByPhysicianAnswered: async (id) => {
    try {
      const response = await axios.get(
        `https://localhost:7239/api/QuestionAnswers/GetAllAnsweredByDoctorTC?doctorTC=${id}`
      )
      return response
    } catch (error) {
      alert(error)
    }
  },

  sendAnswer: async (id, answer) => {
    try {
      return await axios.put(`https://localhost:7239/api/QuestionAnswers/Update?answer=${answer}&id=${id}`)
    } catch (error) {
      alert(error)
    }
  },
}

export default Medicine
