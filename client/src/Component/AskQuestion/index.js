import {
    Drawer,
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
  import {
    IconLogout,
    IconHeart,
    IconStar,
    IconMessage,
    IconSettings,
    IconPlayerPause,
    IconHelpOctagon ,
    IconSwitchHorizontal,
    IconChevronDown,
  } from '@tabler/icons-react'
  import cx from 'clsx'
  import { useEffect, useState } from 'react'
  import Medicine from '../../Services'
  import { useDisclosure } from '@mantine/hooks'
  import '../../Pages/table.css'
  
  function AskQuestion() {
     // Mantine Hooks
  const [opened, { open, close }] = useDisclosure(false)

    return (
      <>
        <Drawer opened={opened} onClose={close} title="Authentication">
 "ehehehehe"
</Drawer>
                      <IconHelpOctagon 
                onClick={open}
                style={{ width: rem(30), height: rem(30) }}
                stroke={2.4}
                />
        </>
    )
  }
  
  export default AskQuestion
  