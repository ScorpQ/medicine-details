import { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom'
import Medicine from '../Services'
import { Avatar, Badge, Table, Group, Text, Select } from '@mantine/core'

const Patient = () => {
  let { id } = useParams()
  const [medicineData, setMedicineData] = useState()

  const getMedicine = async () => {
    const response = await Medicine.getMedicineData(id)
    setMedicineData(response)
  }

  useEffect(() => {
    getMedicine()
  }, [])

  const rows =
    medicineData &&
    medicineData.data.data.map((item) => (
      <Table.Tr key={item.id}>
        <Table.Td>
          <Group gap='sm'>
            <Avatar size={40} src={item.avatar} radius={40} />
            <div>
              <Text fz='sm' fw={500}>
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
    </>
  )
}

export default Patient
