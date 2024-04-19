import Patient from './Pages/Patient'
import Physician from './Pages/Physician'
import Login from './Pages/Login'
import { Notifications } from '@mantine/notifications'
import { createBrowserRouter, RouterProvider, createRoutesFromElements, Route } from 'react-router-dom'
import { MantineProvider } from '@mantine/core'

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
        <Notifications />
        <RouterProvider router={routerX} />
      </MantineProvider>
    </>
  )
}

export default App
