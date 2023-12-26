import Medicine from '../../Services'
import { useState } from 'react'
import { useNavigate } from 'react-router-dom'

// mantine imports
import { useDisclosure } from '@mantine/hooks'
import { Drawer, Button } from '@mantine/core'

const PatientLogin = () => {
  const [id, setId] = useState()
  const [password, setPassword] = useState()
  const [opened, { open, close }] = useDisclosure(false)
  const navigate = useNavigate()

  const handleChangeID = ({ target }) => {
    setId(target.value)
  }
  const handleChangePassword = ({ target }) => {
    setPassword(target.value)
  }

  const login = async () => {
    const result = await Medicine.Patientlogin(id, password)
    result ? navigate(`/patient/${result.data}`) : console.log('bilgi hata')
  }

  return (
    <>
      <Drawer opened={opened} onClose={close} title='Patient'>
        <input placeholder='Enter your TC here' onChange={handleChangeID} />
        <input placeholder='Enter your password here' onChange={handleChangePassword} />
        <input type='button' value={'Log In'} onClick={login} />
      </Drawer>
      <Button onClick={open}>Patient</Button>
    </>
  )
}

export default PatientLogin
