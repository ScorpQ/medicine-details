import PhysicianLogin from './Component/PhysicianLogin'
import PatientLogin from './Component/PatientLogin'
import Patient from './Pages/Patient'
import Physician from './Pages/Physician'
import Login from './Pages/Login'
import Root from './'
import { createBrowserRouter, RouterProvider, createRoutesFromElements, Route } from 'react-router-dom'
import { createTheme, MantineProvider } from '@mantine/core'

import './App.css'

const routerX = createBrowserRouter(
  createRoutesFromElements(
    <Route>
      <Route path='/' element={<Login />} />
      <Route path='patient/:id' element={<Patient />} />
      <Route path='physician/:id' element={<Physician />} />
    </Route>
  )
)

function App() {
  return (
    <>
      <MantineProvider>
        <RouterProvider router={routerX} />
      </MantineProvider>
    </>
  )
}

export default App
