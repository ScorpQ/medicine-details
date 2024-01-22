import {
  Avatar,
  Anchor,
  Autocomplete,
  Badge,
  Box,
  Button,
  Center,
  Card,
  Container,
  Combobox,
  Table,
  TextInput,
  Textarea,
  Select,
  SegmentedControl,
  Space,
  NumberInput,
  UnstyledButton,
  Menu,
  Modal,
  Flex,
  Mark,
  Image,
  InputBase,
  Text,
  Tabs,
  useCombobox,
  Burger,
  rem,
  useMantineTheme,
} from '@mantine/core'
import { useEffect, useState } from 'react'
import Medicine from '../../Services'
import { useDisclosure } from '@mantine/hooks'
import '../../Pages/table.css'

function AddPrescription({ docId, onRequest }) {
  const [opened, { open, close }] = useDisclosure(false)
  const [patientID, setPatientID] = useState('')
  const [medicineList, setMedicineList] = useState()
  const [periodList, setPeriodList] = useState()
  const [segmentValue, setSegmentValue] = useState('react')
  const [count, setCount] = useState()
  const [descrip, setDescrip] = useState()

  // ComboBox Hooks
  const [comboValue, setComboValue] = useState('')
  const [comboSearch, setComboSearch] = useState('')

  // fetch all medicine list
  const medicinesAndperiod = async () => {
    setMedicineList(await Medicine.medicines(docId))
    setPeriodList(await Medicine.period())
  }

  // ComboBox Options
  const combobox = useCombobox({
    onDropdownClose: () => combobox.resetSelectedOption(),
  })

  useEffect(() => {
    medicinesAndperiod()
  }, [])

  const shouldFilterOptions = medicineList?.data?.data.every((item) => item.medicineName !== comboSearch)
  const filteredOptions = shouldFilterOptions?.data?.data
    ? medicineList?.data?.data.filter((item) =>
        item.medicineName.toLowerCase().includes(comboSearch.toLowerCase().trim())
      )
    : medicineList?.data?.data

  const options = filteredOptions?.map((item) => (
    <Combobox.Option value={item} key={item.id}>
      {item.medicineName}
    </Combobox.Option>
  ))

  const addPrescription = async () => {
    return await Medicine.addPrescription(
      docId,
      patientID,
      comboValue.id,
      '2024-01-13T08:49:43.456Z', //Static
      '2024-01-20T08:49:43.456Z', //Static
      segmentValue, //Static
      count.toString(), //Static
      descrip.toString() //Static
    )
  }

  return (
    <>
      <Modal opened={opened} onClose={close} title='Reçete Kayıt' size={'auto'}>
        <TextInput
          label='Hasta Kimlik Numarası'
          placeholder='Kimlik numarası'
          onChange={(event) => setPatientID(event.currentTarget.value)}
        />
        <Space h='md' />
        <Combobox
          store={combobox}
          label='İlaçlar'
          withinPortal={false}
          onOptionSubmit={(val) => {
            setComboValue(val)
            setComboSearch(val)
            combobox.closeDropdown()
          }}
        >
          <Combobox.Target>
            <InputBase
              rightSection={<Combobox.Chevron />}
              value={comboSearch.medicineName}
              onChange={(event) => {
                combobox.openDropdown()
                combobox.updateSelectedOptionIndex()
                setComboSearch(event.currentTarget.value)
              }}
              onClick={() => combobox.openDropdown()}
              onFocus={() => combobox.openDropdown()}
              onBlur={() => {
                combobox.closeDropdown()
                setComboSearch(comboValue || '')
              }}
              placeholder='İlaç seç'
              rightSectionPointerEvents='none'
            />
          </Combobox.Target>

          <Combobox.Dropdown className='comboDropdown'>
            <Combobox.Options>
              {options?.length > 0 ? options : <Combobox.Empty>Nothing found</Combobox.Empty>}
            </Combobox.Options>
          </Combobox.Dropdown>
        </Combobox>
        <Space h='md' />
        <SegmentedControl
          color='blue'
          value={segmentValue}
          onChange={setSegmentValue}
          transitionDuration={500}
          data={periodList?.data?.data?.map((item) => ({
            label: item.timeOfUseName,
            value: item.id,
          }))}
        />
        <Space h='md' />
        <NumberInput label='Kullanım Miktarı' placeholder='0' min={1} max={4} onChange={setCount} />
        <Space h='md' />
        <Textarea
          label='İlaç Kullanım Bilgileri'
          placeholder='....'
          onChange={(event) => setDescrip(event.currentTarget.value)}
        />
        <Space h='md' />
        <Button
          onClick={() => {
            addPrescription()
            onRequest()
          }}
        >
          Ekle
        </Button>
      </Modal>

      <Button
        onClick={() => {
          open()
        }}
      >
        Reçete Ekle
      </Button>
    </>
  )
}

export default AddPrescription
