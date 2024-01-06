import { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom'
import Medicine from '../Services'
import { useDisclosure } from '@mantine/hooks'
import {
  Avatar,
  Badge,
  Table,
  Group,
  Text,
  Select,
  Container,
  UnstyledButton,
  Menu,
  Tabs,
  Modal,
  Button,
  Burger,
  rem,
  useMantineTheme,
} from '@mantine/core'
import {
  IconLogout,
  IconHeart,
  IconStar,
  IconMessage,
  IconSettings,
  IconPlayerPause,
  IconTrash,
  IconSwitchHorizontal,
  IconChevronDown,
} from '@tabler/icons-react'
import cx from 'clsx'
import './table.css'
/*
const user = {
  name: 'Jane Spoonfighter',
  email: 'janspoon@fighter.dev',
  image: 'https://raw.githubusercontent.com/mantinedev/mantine/master/.demo/avatars/avatar-5.png',
}

const tabs = ['Home', 'Orders', 'Education', 'Community', 'Forums', 'Support', 'Account', 'Helpdesk']
*/

const xxx = () => {}

const Patient = () => {
  // React Hooks
  let { id } = useParams()
  const [medicineData, setMedicineData] = useState()

  // Mantine Hooks
  const [opened, { open, close }] = useDisclosure(false)

  const getMedicine = async () => {
    const response = await Medicine.getPatientReports(id)
    setMedicineData(response)
  }

  useEffect(() => {
    getMedicine()
  }, [])

  const rows =
    medicineData &&
    medicineData.data.data.map((item) => (
      <Table.Tr
        key={item.id}
        className='tableRow'
        onClick={() => {
          open()
          xxx()
        }}
      >
        <Table.Td>
          <Group gap='sm' wrap='nowrap'>
            <Avatar size={75} src={item.imagePath} radius={40} />
            <div>
              <Badge fz='md' color='blue' radius='md'>
                {item.medicineName}
              </Badge>
              <Text fz='md' c='dimmed'>
                {item.medicineTypeName}
              </Text>
            </div>
          </Group>
        </Table.Td>
        <Table.Td>
          <Text fz='sm'>{item.departmentName}</Text>
          <Text fz='xs' c='dimmed'>
            {item.doctorName + ' ' + item.doctorLastname}
          </Text>
        </Table.Td>
        <Table.Td>
          <Text fz='sm'>{item.timeOfUseName}</Text>
          <Text fz='xs' c='dimmed'>
            {`Kullanım miktarı: ${item.timeOfUse}`}
          </Text>
        </Table.Td>
        <Table.Td>
          <Text fz='sm'>{item.info}</Text>
          <Text fz='xs' c='dimmed'>
            Prospektüs
          </Text>
        </Table.Td>
        <Table.Td>
          <Text fz='sm'>{item.startDate}</Text>
          <Text fz='xs' c='dimmed'>
            Başlangıç
          </Text>
        </Table.Td>
        <Table.Td>
          <Text fz='sm'>{item.endDate}</Text>
          <Text fz='xs' c='dimmed'>
            Bitiş
          </Text>
        </Table.Td>
      </Table.Tr>
    ))

  return (
    <>
      <Table.ScrollContainer minWidth={800}>
        <Table verticalSpacing='sm'>
          <Table.Thead>
            <Table.Tr>
              <Table.Th>İlaçlar</Table.Th>
              <Table.Th>Departman</Table.Th>
              <Table.Th>Kullanım Vakti</Table.Th>
              <Table.Th>Bilgi</Table.Th>
              <Table.Th>Başlangıç Tarihi</Table.Th>
              <Table.Th>Bitiş Tarihi</Table.Th>
            </Table.Tr>
          </Table.Thead>
          <Table.Tbody>{rows}</Table.Tbody>
        </Table>
      </Table.ScrollContainer>
      <p>
        Kullanıcı: {medicineData && medicineData.data.data[0].patientName}{' '}
        {medicineData && medicineData.data.data[0].patientLastname}
      </p>
      <Modal opened={opened} onClose={close} title='Authentication'>
        asdfasdf
      </Modal>
    </>
  )
}

export default Patient
