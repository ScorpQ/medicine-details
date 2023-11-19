import data from './Services'
import './App.css'
import { useEffect } from 'react'

function App() {
  useEffect(() => {
    data.getUser()
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
        <input type='button' value={'Log in'} />
      </div>
    </>
  )
}

export default App
