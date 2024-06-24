import { useParams } from 'react-router-dom'
import { useEffect, useState } from 'react'
// Mantine Imports
import '@mantine/core/styles.css'
import Medicine from '../Services'
import classess from '../Component/AskQuestion/BadgeCard.module.css'
import '@mantine/notifications/styles.css'
import { notifications } from '@mantine/notifications'
import {
  Alert,
  AppShell,
  Textarea,
  Space,
  Button,
  Badge,
  Group,
  ScrollArea,
  Skeleton,
  Card,
  Container,
  Image,
  UnstyledButton,
  Avatar,
  Text,
  Tabs,
  Modal,
} from '@mantine/core'
import { useDisclosure } from '@mantine/hooks'
import { IconChevronRight, IconMessageCircle, IconInfoCircle } from '@tabler/icons-react'
import classes from './ArticleCardVertical.module.css'

import { useNavigate } from 'react-router-dom'

const QuestionList = () => {
  let { id } = useParams()
  const navigate = useNavigate()

  const [opened, { open, close }] = useDisclosure(false)
  const [notAnswereds, setNotAnswereds] = useState()
  const [answereds, setAnswereds] = useState()
  const [clicked, setClicked] = useState()
  const [descrip, setDescrip] = useState()

  const getAnswereds = async () => {
    const response = await Medicine.getQuestionsByPhysicianAnswered(id)
    setAnswereds(response)
  }

  const getNotAnswereds = async () => {
    const response = await Medicine.getQuestionsByPhysicianNotAnswered(id)
    setNotAnswereds(response)
  }

  function truncateText(text, maxLength) {
    if (text.length > maxLength) {
      return text.substring(0, maxLength) + '...'
    }
    return text
  }

  const sendAnswer = async (questionId, asnwer) => {
    const response = await Medicine.sendAnswer(questionId, asnwer)
  }

  useEffect(() => {
    getAnswereds()
    getNotAnswereds()
  }, [])

  return (
    <Tabs defaultValue='Cevaplanmamış'>
      <AppShell header={{ height: 60 }} navbar={{ width: 300, breakpoint: 'sm' }} padding='md'>
        <AppShell.Header>
          <header>
            <Container size='lg' className='inner'>
              <UnstyledButton className='ab' pl={10} pt={10}>
                <Group>
                  <Avatar
                    src='https://raw.githubusercontent.com/mantinedev/mantine/master/.demo/avatars/avatar-3.png'
                    radius='xl'
                  />
                  <div style={{ flex: 1 }}>
                    <Text size='sm' fw={500}>
                      {`DR. ${notAnswereds?.data.data[0].doctorName} ${notAnswereds?.data.data[0].doctorSurname}`}
                      {console.log(notAnswereds)}
                    </Text>
                  </div>
                  <IconChevronRight />
                </Group>
              </UnstyledButton>
              <Button
                onClick={() => {
                  navigate(`/physician/${id}`)
                }}
              >
                Reçete Paneli
              </Button>
            </Container>
          </header>
        </AppShell.Header>
        <AppShell.Navbar p='xs' w='400'>
          <AppShell.Section>
            {' '}
            <Tabs.List>
              <Tabs.Tab value='Cevaplanmış' leftSection={<IconMessageCircle />}>
                Cevaplanmış
              </Tabs.Tab>
              <Tabs.Tab value='Cevaplanmamış' leftSection={<IconMessageCircle />}>
                Cevaplanmamış
              </Tabs.Tab>
            </Tabs.List>
          </AppShell.Section>
          <AppShell.Section grow my='md' component={ScrollArea}>
            <Tabs.Panel value='Cevaplanmış'>
              {answereds?.data?.data.map((item) => (
                <Card
                  withBorder
                  radius='md'
                  p={0}
                  className={classes.card}
                  onClick={() => {
                    open()
                    setClicked(item)
                  }}
                >
                  <Group wrap='nowrap' gap={0} pr={20}>
                    <div className={classes.body}>
                      <Badge color='teal' size='md'>
                        {item.medicineName}
                      </Badge>
                      <Text className={classes.title} mt='xs' mb='md'>
                        {truncateText(item.question, 70)}
                      </Text>
                      <Group wrap='nowrap' gap='xs'>
                        <Group gap='xs' wrap='nowrap'>
                          <Avatar variant='filled' radius='sm' size='sm' color='green' src='' />
                          <Text fw={500} size='xs'>{`Hasta ${item.patientName} ${item.patientSurname}`}</Text>
                        </Group>
                        <Text size='sm' c='green'>
                          •
                        </Text>
                        <Text size='xs' c='dimmed'>
                          {item.patientTC}
                        </Text>
                      </Group>
                    </div>
                  </Group>
                </Card>
              ))}
            </Tabs.Panel>
            <Tabs.Panel value='Cevaplanmamış'>
              {notAnswereds?.data?.data.map((item) => (
                <Card
                  withBorder
                  radius='md'
                  p={0}
                  className={classes.card}
                  onClick={() => {
                    open()
                    setClicked(item)
                  }}
                >
                  <Group wrap='nowrap' gap={0} pr={20}>
                    <div className={classes.body}>
                      <Badge color='teal' size='md'>
                        {item.medicineName}
                      </Badge>
                      <Text className={classes.title} mt='xs' mb='md'>
                        {truncateText(item.question, 70)}
                      </Text>
                      <Group wrap='nowrap' gap='xs'>
                        <Group gap='xs' wrap='nowrap'>
                          <Avatar variant='filled' radius='sm' size='sm' color='green' src='' />
                          <Text fw={500} size='xs'>{`Hasta ${item.patientName} ${item.patientSurname}`}</Text>
                        </Group>
                        <Text size='sm' c='green'>
                          •
                        </Text>
                        <Text size='xs' c='dimmed'>
                          {item.patientTC}
                        </Text>
                      </Group>
                    </div>
                  </Group>
                </Card>
              ))}
            </Tabs.Panel>
            <Tabs.Panel value='messages'>Messages tab content</Tabs.Panel>
          </AppShell.Section>
          <AppShell.Section>Test Footer Test</AppShell.Section>
        </AppShell.Navbar>
        <AppShell.Main>Main</AppShell.Main>
      </AppShell>
      <Modal opened={opened} onClose={close} title='Cevaplama Paneli' yOffset='100px' xOffset='500px'>
        <Badge color='teal' size='md'>
          {`İlaç: ${clicked?.medicineName}`}
        </Badge>
        <Card>
          <Card.Section className={classess.section} mt='md'>
            <Group justify='apart'>
              <Text fz='lg' fw={500}>
                {`Hastanın sorusu`}
                {console.log(clicked)}
              </Text>
              <Badge size='sm' variant='light'>
                {`Hasta ${clicked?.patientName} ${clicked?.patientSurname}`}
              </Badge>
            </Group>
            <Text fz='sm' mt='xs' fw={400}>
              {clicked?.question}
            </Text>
          </Card.Section>

          <Card.Section className={classess.section} mt='md'>
            <Group justify='apart'>
              <Text fz='lg' fw={500}>
                {`Cevabınız`}
              </Text>
              <Badge size='sm' variant='light'>
                {`Dr. ${clicked?.doctorName} ${clicked?.doctorSurname}`}
              </Badge>
            </Group>
            {clicked?.answered ? (
              <Alert variant='light' color='teal' radius='md' title='Cevapladınız' icon={<IconInfoCircle />}>
                {clicked.answer}
              </Alert>
            ) : (
              <>
                <Textarea
                  placeholder='...'
                  mt='md'
                  autosize
                  minRows={7}
                  onChange={(event) => setDescrip(event.currentTarget.value)}
                />
                <Space h='sm' />
                <Button
                  variant='gradient'
                  gradient={{ from: 'green', to: 'indigo', deg: 91 }}
                  onClick={() => {
                    open()
                    sendAnswer(clicked.id, descrip)
                    notifications.show({
                      title: 'Cevabınız gönderildi.',
                      message: 'Bu pencere 5 saniye sonra kapanacak.',
                    })
                  }}
                >
                  Cevabı gönder.
                </Button>
              </>
            )}
          </Card.Section>
        </Card>
      </Modal>
    </Tabs>
  )
}

export default QuestionList
