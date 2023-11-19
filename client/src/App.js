import Medicine from './Services'
import './App.css'
import { useEffect } from 'react'

function App() {
  useEffect(() => {
    Medicine.getUser()
  })

  return (
    <>
      <h1>Login</h1>
      <div>
        <input placeholder='Enter your TC here' />
      </div>
      <div>
        <input placeholder='Enter your password here' />
      </div>
      <div>
        <input type='button' value={'Log in'} onClick={() => {
          Medicine.login('30328905022','1234')
        }} />
      </div>
    </>
  )
}

export default App
