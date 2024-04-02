import { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom'
import { IconChevronRight } from '@tabler/icons-react'
import AddPrescription from '../Component/AddPrescription'

import Medicine from '../Services'
import {
  Avatar,
  Anchor,
  Badge,
  Box,
  Button,
  Center,
  Card,
  Table,
  Select,
  Container,
  UnstyledButton,
  Menu,
  Flex,
  Mark,
  Image,
  ActionIcon,
  Text,
  Group,
  Tabs,
  Modal,
  Burger,
  rem,
  useMantineTheme,
} from '@mantine/core'
import { useDisclosure } from '@mantine/hooks'
import { IconTrash } from '@tabler/icons-react'
import './table.css'

const Physician = () => {
  // React Hooks
  let { id } = useParams()
  const [reportsData, setReportsData] = useState()
  const [selectedMedicine, setSelectedMedicine] = useState()

  // Mantine hooks
  const theme = useMantineTheme()
  const [userMenuOpened, setUserMenuOpened] = useState(false)
  const [opened, { open, close }] = useDisclosure(false)
  const [openedd, { toggle }] = useDisclosure(false)

  // Mantine Header
  const getReports = async () => {
    const response = await Medicine.getPhysicianReports(id)
    setReportsData(response)
  }

  const getDetails = async (id, pid) => {
    const response = await Medicine.getMedicineDetails(id, pid)
    setSelectedMedicine(response)
  }

  const deletePrescription = async (id) => {
    const response = await Medicine.deletePrescription(id)
    getReports()
  }

  useEffect(() => {
    getReports()
  }, [])

  const rows = reportsData?.data.data.map((item) => (
    <Table.Tr key={item.id} className='tableRow'>
      <Table.Td
        onClick={() => {
          open()
          getDetails(item.medicineId, item.id)
        }}
      >
        <Group gap='sm' wrap='nowrap'>
          <Avatar className='imgScale' bg='white' size={95} src={item.imagePath} radius={10} />
          <Box pl={15}>
            <Badge fz='md' color='blue' radius='md'>
              {item.medicineName}
            </Badge>
            <Text fz='md' c='dimmed' pl={10}>
              {item.medicineTypeName}
            </Text>
          </Box>
        </Group>
      </Table.Td>
      <Table.Td
        onClick={() => {
          open()
          getDetails(item.medicineId, item.id)
        }}
      >
        <Text fz='md' fw={500}>
          {`Dr. ${item.doctorName} ${item.doctorLastname}`}
        </Text>
        <Text fz='sm' c='dimmed'>
          {item.departmentName}
        </Text>
      </Table.Td>
      <Table.Td
        onClick={() => {
          open()
          getDetails(item.medicineId, item.id)
        }}
      >
        <Text fz='md'>{item.timeOfUseName}</Text>
        <Text fz='md' c='dimmed' td='underline'>
          Kullanım miktarı:{' '}
          <Text display='inline' c='blue'>
            {item.pieces}
          </Text>
        </Text>
      </Table.Td>
      <Table.Td
        onClick={() => {
          open()
          getDetails(item.medicineId, item.id)
        }}
      >
        <Text fz='md' fw={400}>
          {`${item.patientName} ${item.patientLastname}`}
        </Text>
      </Table.Td>
      <Table.Td
        onClick={() => {
          open()
          getDetails(item.medicineId, item.id)
        }}
      >
        <Badge color='green' size='md' fz='xs'>
          Kullanım Talimati
        </Badge>
        <Text pl={5} fz='md'>
          {item.info}
        </Text>
      </Table.Td>
      <Table.Td
        onClick={() => {
          open()
          getDetails(item.medicineId, item.id)
        }}
      >
        <Badge size='lg' fz='md' fw={500}>
          {/*console.log(
              Date(item.endDate) > Date() ? Date(item.endDate) + ' X ' + Date() : Date(item.endDate) + ' X ' + Date()
            )*/}
          {item.startDate.slice(0, 10)}
        </Badge>
        <Text fz='md' c='dimmed' pl={15}>
          Başlangıç
        </Text>
      </Table.Td>
      <Table.Td>
        <Badge size='lg' fz='md' fw={500} bg='#d10000'>
          {item.endDate.slice(0, 10)}
        </Badge>
        <Text fz='md' c='dimmed' pl={35}>
          Bitiş
        </Text>
      </Table.Td>
      <Table.Td>
        <ActionIcon variant='subtle' color='red'>
          <IconTrash
            onClick={() => deletePrescription(item.id)}
            style={{ width: rem(20), height: rem(20) }}
            stroke={2.4}
          />
        </ActionIcon>
      </Table.Td>
    </Table.Tr>
  ))

  return (
    <>
      <header className='A'>
        <Container size='md' className='inner'>
          <UnstyledButton className='ab' pl={10} pt={10}>
            <Group>
              <Avatar
                src='https://raw.githubusercontent.com/mantinedev/mantine/master/.demo/avatars/avatar-3.png'
                radius='xl'
              />
              <div style={{ flex: 1 }}>
                <Text size='sm' fw={500}>
                  {`DR. ${reportsData?.data.data[0]?.doctorName} ${reportsData?.data.data[0]?.doctorLastname}`}
                </Text>
              </div>
              <IconChevronRight />
            </Group>
          </UnstyledButton>
          <Group gap={5} visibleFrom='xs'>
            <AddPrescription docId={id} onRequest={getReports} />
          </Group>
          <Burger opened={openedd} onClick={toggle} hiddenFrom='xs' size='sm' />
        </Container>
      </header>
      <Table.ScrollContainer minWidth={800}>
        <Table verticalSpacing='sm'>
          <Table.Thead>
            <Table.Tr fz='lg' fw={900}>
              <Table.Th>İlaçlar</Table.Th>
              <Table.Th>Hastane</Table.Th>
              <Table.Th>Kullanım Vakti</Table.Th>
              <Table.Th>Hasta</Table.Th>
              <Table.Th>Bilgi</Table.Th>
              <Table.Th>Başlangıç Tarihi</Table.Th>
              <Table.Th>Bitiş Tarihi</Table.Th>
            </Table.Tr>
          </Table.Thead>
          <Table.Tbody>{rows}</Table.Tbody>
        </Table>
      </Table.ScrollContainer>

      <Modal opened={opened} onClose={close} title='İlaç Bilgi'>
        {/* 
        {console.log(selectedMedicine?.data?.data[0])}
        {selectedMedicine?.data?.data[0].id}
        {selectedMedicine?.data?.data[0].imagePath}
        {selectedMedicine?.data?.data[0].medicineId}
        {selectedMedicine?.data?.data[0].medicineName}
        {selectedMedicine?.data?.data[0].webSite}
        {selectedMedicine?.data?.data[0].doctorPrescriptionInfo}
        */}
        <Card withBorder radius='md' className='card'>
          <Card.Section className='imageSection'>
            <Image
              className='imageSection'
              h={250}
              w={250}
              fit='contain'
              src={`https://localhost:7239/Uploads/MedicineImages/${selectedMedicine?.data?.data[0].imagePath}`}
              alt={selectedMedicine?.data?.data[0].medicineName}
            />
          </Card.Section>

          <Group justify='space-between' mt='md'>
            <div>
              <Text fw={500}>{selectedMedicine?.data?.data[0].medicineName}</Text>
              <Text fz='xs' c='dimmed'>
                {`İlaç ID: ${selectedMedicine?.data?.data[0].medicineId}`}
              </Text>
            </div>
            <Badge variant='outline'>{selectedMedicine?.data?.data[0].medicineTypeName}</Badge>
          </Group>

          <Card.Section className='section' mt='md'>
            <Text fz='sm' c='dimmed' className='label'>
              {selectedMedicine?.data?.data[0].doctorPrescriptionInfo}
            </Text>
          </Card.Section>

          <Group justify='stretch' mt={50}>
            <Button radius='xl' mx={25} style={{ width: '-webkit-fill-available' }}>
              <Anchor c='white' href={selectedMedicine?.data?.data[0].webSite} target='_blank'>
                Prospektüs
              </Anchor>
            </Button>
          </Group>
        </Card>
      </Modal>
    </>
  )
}

export default Physician
