import Medicine from '../../Services'
import { useState } from 'react'
import { useNavigate } from 'react-router-dom'

// mantine imports
import { useDisclosure } from '@mantine/hooks'
import { Card, Avatar, Text, Group, Drawer, Button, Space } from '@mantine/core'
import classes from '../PhysicianLogin/doctor.css'

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

  const imageStyle = {
    backgroundImage: 'url(https://bsweh.org/wp-content/uploads/header_ba_patient_hd.jpg)',
    backgroundPosition: '30% 0%',
    backgroundRepeat: 'no-repeat',
    backgroundSize: '120%',
    padding: '100px',
  }
  const icon = {
    backgroundSize: '220%',
  }

  return (
    <>
      <Card withBorder padding='xl' radius='md' className={classes.card} w={400}>
        <Card.Section h={200} style={imageStyle} />
        <Avatar
          src='https://media.istockphoto.com/id/1097493802/vector/patient-icon-customer-icon-with-add-additional-sign-patient-icon-and-new-plus-positive.jpg?s=612x612&w=0&k=20&c=IrugHP6i-oobykGTLg7kCHP-SPENaDFxhQKAIdM9XuI='
          size={80}
          radius={80}
          style={icon}
          mx='auto'
          mt={-30}
          className={classes.avatar}
        />
        <Text ta='center' h={60} fz='xl' fw={700} mt='sm' mb='sm'>
          Patient Login
        </Text>

        <Drawer opened={opened} onClose={close} title='Patient'>
          <input placeholder='Enter your TC here' onChange={handleChangeID} />
          <input placeholder='Enter your password here' onChange={handleChangePassword} />
          <input type='button' value={'Log In'} onClick={login} />
        </Drawer>
        <Button size='lg' onClick={open} variant='gradient' gradient={{ to: 'teal', from: 'blue', deg: 121 }}>
          Patient
        </Button>
      </Card>
    </>
  )
}

export default PatientLogin
