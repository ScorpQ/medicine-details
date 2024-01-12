import {
  Avatar,
  Anchor,
  Autocomplete,
  Badge,
  Box,
  Button,
  Center,
  Card,
  Table,
  TextInput,
  Select,
  Container,
  UnstyledButton,
  Menu,
  Flex,
  Mark,
  Image,
  Text,
  Group,
  Tabs,
  Modal,
  Burger,
  rem,
  useMantineTheme,
} from '@mantine/core'
import { useState } from 'react'
import Medicine from '../../Services'
import { useDisclosure, useResizeObserver } from '@mantine/hooks'

function AddPrescription({ docId }) {
  const [opened, { open, close }] = useDisclosure(false)
  const [patientID, setPatientID] = useState('')

  const addPrescription = async () => {
    return await Medicine.addPrescription(
      docId, //Static
      patientID, //Static
      5, //Static
      '2024-01-12T08:49:43.456Z', //Static
      '2024-01-20T08:49:43.456Z', //Static
      1, //Static
      '5', //Static
      'Rinoplasti sonrası 2. gün kullanılmaya başlanmalı.' //Static
    )
  }

  return (
    <>
      <Modal opened={opened} onClose={close} title='Authentication'>
        <TextInput
          label='Hasta Kimlik Numarası'
          placeholder='XXXXXX'
          onChange={(event) => setPatientID(event.currentTarget.value)}
        />

        <Button onClick={addPrescription}>Ekle</Button>
      </Modal>

      <Button onClick={open}>Reçete Ekle</Button>
    </>
  )
}

export default AddPrescription
