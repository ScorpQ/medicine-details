import {
  Alert,
  Card,
  Badge,
  Drawer,
  Image,
  Button,
  Text,
  Group,
  Fieldset,
  Textarea,
  Space,
  rem,
  Flex,
  Tooltip,
} from '@mantine/core'
import { IconHelpOctagon, IconInfoCircle } from '@tabler/icons-react'
import '@mantine/notifications/styles.css'
import { notifications } from '@mantine/notifications'
import Medicine from '../../Services'
import { useState } from 'react'
import { useDisclosure } from '@mantine/hooks'
import '../../Pages/table.css'
import classes from './BadgeCard.module.css'

function AskQuestion({ medicineData, id }) {
  // Mantine Hooks
  const [opened, { open, close }] = useDisclosure(false)
  const [focused, setFocused] = useState(false)

  //React Hook
  const [descrip, setDescrip] = useState()
  const [questionLimit, setQuestionLimit] = useState()
  const [questionData, setQuestionData] = useState()

  const IsThereQuestion = async (medicineData) => {
    console.log(medicineData)
    const response = await Medicine.IsThereQuestion(medicineData.id)
    setQuestionLimit(response?.data)
    if (response?.data) {
      const response = await Medicine.getQuestions(medicineData.id)
      console.log(response)
      setQuestionData(response)
    }
  }

  const sendQuestion = async (patientID, doktorTC, prescripId) => {
    const response = await Medicine.sendQuestion(patientID, doktorTC, prescripId, descrip)
  }

  return (
    <>
      <Drawer opened={opened} onClose={close} title='Soru Sorma Paneli'>
        <Space h='xl' />
        <Fieldset legend={`Dr. ${medicineData.doctorName} ${medicineData.doctorLastname}`}>
          <Flex gap='25'>
            <Image className='imgScale' fit='cover' w={130} bg='white' src={medicineData.imagePath} radius={10} />
            <Flex direction='row' gap='50'>
              <Flex direction='column' gap='10'>
                <Badge color='green' size='md' fz='xs'>
                  {medicineData.medicineName}
                </Badge>
                <Badge fz='xs' color='blue' radius='md'>
                  {medicineData.medicineTypeName}
                </Badge>
              </Flex>
              <Tooltip label='Her ilaç hakkında sadece 1 soru sorma hakkınız bulunmaktadır.'>
                <IconHelpOctagon color='red' style={{ width: rem(25), height: rem(25) }} stroke={2.4} />
              </Tooltip>
            </Flex>
          </Flex>
          {!questionLimit ? (
            <>
              <Textarea
                placeholder='Şikayet veya sorununuz nedir?'
                label='Şikayet veya sorununuz nedir?'
                onFocus={() => setFocused(true)}
                onBlur={() => setFocused(false)}
                mt='md'
                autosize
                minRows={7}
                onChange={(event) => setDescrip(event.currentTarget.value)}
              />
              <Space h='sm' />
              <Button
                onClick={() => {
                  open()
                  sendQuestion(id, medicineData.doctorTC, medicineData.id)
                  notifications.show({
                    title: 'Sorunuz gönderildi.',
                    message: 'Bu pencere 3 saniye sonra kapanacak.',
                  })
                }}
                variant='gradient'
                gradient={{ from: 'green', to: 'indigo', deg: 91 }}
              >
                Sorunu Sor.
              </Button>
            </>
          ) : (
            <>
              <Card>
                <Card.Section className={classes.section} mt='md'>
                  <Group justify='apart'>
                    <Text fz='lg' fw={500}>
                      {`Sizin Sorunuz`}
                    </Text>
                    <Badge size='sm' variant='light'>
                      {`Hasta ${medicineData.patientName} ${medicineData.patientLastname}`}{' '}
                    </Badge>
                  </Group>
                  <Text fz='sm' mt='xs' fw={400}>
                    {questionData?.data?.data?.question}
                  </Text>
                </Card.Section>
              </Card>
              <Card>
                <Card.Section className={classes.section} mt='md'>
                  <Group justify='apart'>
                    <Text fz='lg' fw={500}>
                      {`Doktorun Cevabı`}
                    </Text>
                    <Badge size='sm' variant='light'>
                      {`Dr. ${medicineData.doctorName} ${medicineData.doctorLastname}`}{' '}
                    </Badge>
                  </Group>
                  <Text fz='sm' mt='xs'>
                    {questionData?.data?.data?.answer === '' ? (
                      <Alert variant='light' color='cyan' radius='md' title='Beklemede.' icon={<IconInfoCircle />}>
                        Doktorunuz henüz bu soruyu cevaplandırmamış.
                      </Alert>
                    ) : (
                      <Alert variant='light' color='teal' radius='md' title='Cevaplandı.' icon={<IconInfoCircle />}>
                        {questionData?.data?.data?.answer}
                      </Alert>
                    )}
                  </Text>
                </Card.Section>
              </Card>
            </>
          )}
        </Fieldset>
      </Drawer>
      <IconHelpOctagon
        onClick={() => {
          open()
          IsThereQuestion(medicineData)
        }}
        style={{ width: rem(30), height: rem(30) }}
        stroke={2.4}
      />
    </>
  )
}

export default AskQuestion
