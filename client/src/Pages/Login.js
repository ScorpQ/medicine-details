// client imports
import PhysicianLogin from '../Component/PhysicianLogin'
import PatientLogin from '../Component/PatientLogin'
import '@mantine/core/styles.css'
import { Flex, Container } from '@mantine/core'

const Login = () => {
  return (
    <Container size='xs' h={1000}>
      <Flex direction='column' gap={{ base: 'sm', sm: 'lg' }} size={200} justify={'center'}>
        <PhysicianLogin />
        <PatientLogin />
      </Flex>
    </Container>
  )
}

export default Login
