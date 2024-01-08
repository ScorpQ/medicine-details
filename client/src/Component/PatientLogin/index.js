import Medicine from '../../Services'
import { useState } from 'react'
import { useNavigate } from 'react-router-dom'

// mantine imports
import { useDisclosure } from '@mantine/hooks'
import {
  Card,
  Avatar,
  Text,
  TextInput,
  Drawer,
  Button,
  Fieldset,
  Space,
  Group,
  Anchor,
  PasswordInput,
} from '@mantine/core'
import classes from '../PhysicianLogin/doctor.css'

const PatientLogin = () => {
  const [id, setId] = useState()
  const [password, setPassword] = useState()
  const [opened, { open, close }] = useDisclosure(false)
  const navigate = useNavigate()

  // Mantine Hooks
  const [focused, setFocused] = useState(false)
  const [value, setValue] = useState('')
  const floating = value.trim().length !== 0 || focused || undefined

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
          src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTwjl_0ttoVTkLx-8yOgl4U3MJ9ByjsqsQhzZ3tXq4Ca5Hd2Gsx0zcaIfnLpSV5UAFI_8E&usqp=CAU'
          size={80}
          radius={90}
          mx='auto'
          mt={-30}
          className={classes.avatar}
        />
        <Text ta='center' h={60} fz='xl' fw={700} mt='sm' mb='sm'>
          Hasta Giriş Paneli
        </Text>
        <Drawer opened={opened} onClose={close} title='Hasta Paneli'>
          <Space h='xl' />
          <Fieldset legend='Kişisel Bilgiler'>
            <TextInput
              label='Türkiye Cumhuriyet Kimlik Numarası'
              placeholder='XXXXXXXXXXX'
              classNames={classes}
              value={id}
              onChange={(event) => setId(event.currentTarget.value)}
              onFocus={() => setFocused(true)}
              onBlur={() => setFocused(false)}
              mt='md'
              autoComplete='nope'
              data-floating={floating}
              labelProps={{ 'data-floating': floating }}
            />
            <Space h='sm' />
            <Group justify='space-between' mb={5}>
              <Text component='label' htmlFor='your-password' size='sm' fw={500}>
                Şifre
              </Text>

              <Anchor href='#' onClick={(event) => event.preventDefault()} pt={2} fw={500} fz='xs'>
                Şifreni mi unuttun?
              </Anchor>
            </Group>
            <PasswordInput
              placeholder='XXXXX'
              id='your-password'
              value={password}
              onChange={(event) => setPassword(event.currentTarget.value)}
            />
            <Space h='xl' />
            <Button onClick={login} variant='gradient' gradient={{ from: 'green', to: 'indigo', deg: 91 }}>
              Giriş
            </Button>
          </Fieldset>
        </Drawer>

        <Button size='lg' onClick={open} variant='gradient' gradient={{ from: 'teal', to: 'blue', deg: 121 }}>
          Physician
        </Button>
      </Card>
    </>
  )
}

export default PatientLogin
