import { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom'
import Medicine from '../Services'

const Physician = () => {
  let { id } = useParams()

  /*
  useEffect(() => {
    getMedicine()
  }, [])
*/
  return (
    <>
      <h1>{id}</h1>
    </>
  )
}

export default Physician
