import { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom'
import Medicine from '../Services'
import { Avatar, Badge, Table, Modal, Group, Text, Select, Flex, useMantineTheme, Tabs } from '@mantine/core'
import { useDisclosure } from '@mantine/hooks'
import './table.css'

const user = {
  name: 'Jane Spoonfighter',
  email: 'janspoon@fighter.dev',
  image: 'https://raw.githubusercontent.com/mantinedev/mantine/master/.demo/avatars/avatar-5.png',
}

const tabs = ['Home', 'Orders', 'Education', 'Community', 'Forums', 'Support', 'Account', 'Helpdesk']

const xxx = (item) => {
  console.log(`Benim veri: ${item}`)
}

const Physician = () => {
  // React Hooks
  let { id } = useParams()
  const [reportsData, setReportsData] = useState()

  // Mantine hooks
  const theme = useMantineTheme()
  const [userMenuOpened, setUserMenuOpened] = useState(false)
  const [opened, { open, close }] = useDisclosure(false)

  // Mantine Header
  const items = tabs.map((tab) => (
    <Tabs.Tab value={tab} key={tab}>
      {tab}
    </Tabs.Tab>
  ))

  const getReports = async () => {
    const response = await Medicine.getPhysicianReports(id)
    console.log(id)
    setReportsData(response)
  }

  useEffect(() => {
    getReports()
  }, [])

  const rows = reportsData?.data.data.map((item) => (
    <Table.Tr
      key={item.id}
      className='tableRow'
      onClick={() => {
        open()
        xxx(item)
      }}
    >
      <Table.Td>
        <Group gap='sm' wrap='nowrap'>
          <Avatar size={75} src={item.imagePath} radius={10} />
          <div>
            <Text fz='md' fw={500}>
              {item.medicineName}
            </Text>
            <Text fz='xs' c='dimmed'>
              {item.info}
            </Text>
          </div>
        </Group>
      </Table.Td>
      <Table.Td>
        <Text fz='sm'>{item.departmentName}</Text>
        <Text fz='xs' c='dimmed'>
          {item.doctorName + ' Sertan'}
        </Text>
      </Table.Td>
      <Table.Td>
        <Text fz='sm'>{item.timeOfUseName}</Text>
        <Text fz='xs' c='dimmed'>
          {item.timeOfUse}
        </Text>
      </Table.Td>
      <Table.Td>
        <Text fz='lg'>{item.info}</Text>
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
        Kullanıcı: {reportsData?.data.data[0]?.doctorName} {reportsData?.data.data[0]?.doctorLastname}
      </p>
      <Modal opened={opened} onClose={close} title='İlaç Bilgi'>
        asdfasdf
      </Modal>
    </>
  )
}

export default Physician
