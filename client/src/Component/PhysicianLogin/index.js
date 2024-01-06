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
import classes from './doctor.css'

import Medicine from '../../Services'
import { useState } from 'react'
import { useNavigate } from 'react-router-dom'

const stats = [
  { value: '34K', label: 'Followers' },
  { value: '187', label: 'Follows' },
  { value: '1.6K', label: 'Posts' },
]

const PhysicianLogin = () => {
  const navigate = useNavigate()
  const [id, setId] = useState()
  const [password, setPassword] = useState()

  // Mantine Hooks
  const [focused, setFocused] = useState(false)
  const [value, setValue] = useState('')
  const floating = value.trim().length !== 0 || focused || undefined
  const [opened, { open, close }] = useDisclosure(false)

  const handleChangePassword = ({ target }) => {
    setPassword(target.value)
  }

  const login = async () => {
    const result = await Medicine.Physicianlogin(id, password)
    result ? navigate(`/physician/${result.data}`) : console.log('bilgi hata')
  }

  // Mantine UI Loop
  const items = stats.map((stat) => (
    <div key={stat.label}>
      <Text ta='center' fz='lg' fw={500}>
        {stat.value}
      </Text>
      <Text ta='center' fz='sm' c='dimmed' lh={1}>
        {stat.label}
      </Text>
    </div>
  ))

  const imageStyle = {
    backgroundImage:
      'url("https://img.freepik.com/free-photo/smiling-doctor-with-strethoscope-isolated-grey_651396-974.jpg")',
    backgroundPosition: '35% 98%',
    backgroundRepeat: 'no-repeat',
    backgroundSize: '180%',
    padding: '100px',
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
          Doktor Giriş Paneli
        </Text>
        <Drawer opened={opened} onClose={close} title='Doktor Paneli'>
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
                Your password
              </Text>

              <Anchor href='#' onClick={(event) => event.preventDefault()} pt={2} fw={500} fz='xs'>
                Forgot your password?
              </Anchor>
            </Group>
            <PasswordInput
              placeholder='Your password'
              id='your-password'
              value={password}
              onChange={(event) => setPassword(event.currentTarget.value)}
            />
            <Space h='xl' />
            <input type='button' value={'Log In'} onClick={login} />
          </Fieldset>
        </Drawer>

        <Button size='lg' onClick={open} variant='gradient' gradient={{ from: 'teal', to: 'blue', deg: 121 }}>
          Physician
        </Button>
      </Card>
    </>
  )
}

export default PhysicianLogin
