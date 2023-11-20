import Medicine from '../Services'
import { useEffect } from 'react'

const Login = () => {
  useEffect(() => {
    Medicine.getUser()
  })

  return (
    <>
      <h1>Hasta</h1>
      <div>
        <input placeholder='Enter your TC here' />
      </div>
      <div>
        <input placeholder='Enter your password here' />
      </div>
      <div>
        <input
          type='button'
          value={'Log in'}
          onClick={() => {
            Medicine.login('30328905022', '12345')
          }}
        />
      </div>
    </>
  )
}
