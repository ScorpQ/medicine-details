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
  import { useNavigate } from 'react-router-dom'
  
  function SeeQuestions({ docId, onRequest }) {
    const navigate = useNavigate()
  
    return (
      <>
        
  
        <Button
          onClick={() => {
            navigate(`/faq/${docId}`)
          }}
        >
          Soruları Görüntüle
        </Button>
      </>
    )
  }
  
  export default SeeQuestions
  