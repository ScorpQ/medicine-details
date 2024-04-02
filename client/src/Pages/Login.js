// client imports
import PhysicianLogin from '../Component/PhysicianLogin'
import PatientLogin from '../Component/PatientLogin'

// Mantine Imports
import '@mantine/core/styles.css'
import { Flex } from '@mantine/core'

const Login = () => {
  return (
    <Flex direction='row' gap={100} justify={'center'} align={'center'} wrap='wrap' h={'90vh'}>
      <PhysicianLogin />
      <PatientLogin />
    </Flex>
  )
}

export default Login
