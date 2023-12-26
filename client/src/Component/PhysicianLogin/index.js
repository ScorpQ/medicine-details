// mantine imports
import { useDisclosure } from '@mantine/hooks'
import { Drawer, Button } from '@mantine/core'

import Medicine from '../../Services'
import { useState } from 'react'
import { useNavigate } from 'react-router-dom'

const PhysicianLogin = () => {
  const [id, setId] = useState()
  const [password, setPassword] = useState()
  const navigate = useNavigate()
  const [opened, { open, close }] = useDisclosure(false)

  const handleChangeID = ({ target }) => {
    setId(target.value)
  }
  const handleChangePassword = ({ target }) => {
    setPassword(target.value)
  }

  const login = async () => {
    const result = await Medicine.Physicianlogin(id, password)
    result ? navigate(`/physician/${result.data}`) : console.log('bilgi hata')
  }

  return (
    <>
      <Drawer opened={opened} onClose={close} title='Physician'>
        <input placeholder='Enter your TC here' onChange={handleChangeID} />
        <input placeholder='Enter your password here' onChange={handleChangePassword} />
        <input type='button' value={'Log In'} onClick={login} />
      </Drawer>
      <Button onClick={open}>Physician</Button>
    </>
  )
}

export default PhysicianLogin
