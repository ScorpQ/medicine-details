import { useParams } from 'react-router-dom'
import { useEffect, useState } from 'react'
// Mantine Imports
import '@mantine/core/styles.css'
import Medicine from '../Services'
import {
  AppShell,
  Button,
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
} from '@mantine/core'
import { useDisclosure } from '@mantine/hooks'
import { IconChevronRight, IconMessageCircle } from '@tabler/icons-react'
import classes from './ArticleCardVertical.module.css'

import { useNavigate } from 'react-router-dom'

const QuestionList = () => {
  const [opened, { toggle }] = useDisclosure()
  const [notAnswereds, setNotAnswereds] = useState()
  const [answereds, setAnswereds] = useState()

  let { id } = useParams()
  const navigate = useNavigate()

  const getAnswereds = async () => {
    const response = await Medicine.getQuestionsByPhysicianAnswered(id)
    setAnswereds(response)
    console.log(response)
  }

  const getNotAnswereds = async () => {
    const response = await Medicine.getQuestionsByPhysicianNotAnswered(id)
    setNotAnswereds(response)
    console.log(response.data.data)
  }

  function truncateText(text, maxLength) {
    if (text.length > maxLength) {
      return text.substring(0, maxLength) + '...'
    }
    return text
  }

  useEffect(() => {
    getAnswereds()
    getNotAnswereds()
  }, [])

  return (
    <Tabs defaultValue='Cevaplanmış'>
      <AppShell
        header={{ height: 60 }}
        navbar={{ width: 300, breakpoint: 'sm', collapsed: { mobile: !opened } }}
        padding='md'
      >
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
                      {`DR. XXX`}
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
              Cevaplanmış tab 60 links in a scrollable section
              {Array(60)
                .fill(0)
                .map((_, index) => (
                  <Skeleton key={index} h={28} mt='sm' animate={false} />
                ))}
            </Tabs.Panel>
            <Tabs.Panel value='Cevaplanmamış'>
              {notAnswereds?.data?.data.map((item) => (
                <Card withBorder radius='md' p={0} className={classes.card}>
                  <Group wrap='nowrap' gap={0} pr={20}>
                    <div className={classes.body}>
                      <Text tt='uppercase' c='dimmed' fw={700} size='xs'>
                        fucidine
                      </Text>
                      <Text className={classes.title} mt='xs' mb='md'>
                        {truncateText(
                          'SORUSORUSORUSORUSORUSORUSORUSORUSORUSORUSORUSORUSORUSORUSORUSORUSORUSORUSORUSORUSORUSORUSORUSORUSORU',
                          30
                        )}
                      </Text>
                      <Group wrap='nowrap' gap='xs'>
                        <Group gap='xs' wrap='nowrap'>
                          <Avatar variant='filled' radius='sm' size='sm' color='green' src='' />
                          <Text size='xs'>Erkan Baş</Text>
                        </Group>
                        <Text size='sm' color='green' c='green'>
                          •
                        </Text>
                        <Text size='xs' c='dimmed'>
                          Feb 6th
                        </Text>
                      </Group>
                    </div>
                  </Group>
                </Card>
              ))}
            </Tabs.Panel>
            <Tabs.Panel value='messages'>Messages tab content</Tabs.Panel>
          </AppShell.Section>
          <AppShell.Section>Navbar footer – always at the bottom</AppShell.Section>
        </AppShell.Navbar>
        <AppShell.Main>Main</AppShell.Main>
      </AppShell>
    </Tabs>
  )
}

export default QuestionList