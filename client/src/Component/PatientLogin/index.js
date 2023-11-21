import Medicine from '../../Services'
import { useState } from 'react'

const PatientLogin = () => {
  const [id, setId] = useState()
  const [password, setPassword] = useState()

  const handleChangeID = ({ target }) => {
    setId(target.value)
  }
  const handleChangePassword = ({ target }) => {
    setPassword(target.value)
  }

  const login = async () => {
    const result = await Medicine.Patientlogin(id, password)
    return result ? console.log('yönlendir.') : console.log('hatalı')
  }

  return (
    <>
      <h1>Patient</h1>
      <input placeholder='Enter your TC here' onChange={handleChangeID} />
      <input placeholder='Enter your password here' onChange={handleChangePassword} />
      <input type='button' value={'Log In'} onClick={login} />
    </>
  )
}

export default PatientLogin
